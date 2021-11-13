import 'dart:convert';
import 'dart:ui';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart' show rootBundle;
import 'package:flutter_chat_types/flutter_chat_types.dart' as types;
import 'package:flutter_chat_ui/flutter_chat_ui.dart';
import 'package:intl/date_symbol_data_local.dart';
import 'package:mime/mime.dart';
import 'package:open_file/open_file.dart';
import 'package:put387/models/poruke_model.dart';
import 'package:put387/models/voznje_model.dart';
import 'package:put387/services/APIService.dart';
import 'package:uuid/uuid.dart';

void main() {
  initializeDateFormatting().then((_) => runApp(const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      home: ChatPage(usernameSearch: '',),
    );
  }
}

class ChatPage extends StatefulWidget {
  final Voznja? voznja;
  final String? voznjaId;
  final String? usernameId;
  final String usernameSearch;
  const ChatPage({Key? key,this.voznja, required this.usernameSearch, this.voznjaId, this.usernameId}) : super(key: key);

  @override
  _ChatPageState createState() => _ChatPageState();
}

class _ChatPageState extends State<ChatPage> {
  List<types.Message> _messages = [];
  final _user = const types.User(id: "111",firstName:"nestoo");


  @override
  void initState() {
    super.initState();
    _loadMessages();
  }

  void _addMessage(types.Message message) {
    setState(() {
      _messages.insert(0, message);
    });
  }

  void _handleMessageTap(types.Message message) async {
    if (message is types.FileMessage) {
      await OpenFile.open(message.uri);
    }
  }


  Future<void> _handleSendPressed(types.PartialText message) async {
    final textMessage = types.TextMessage(
      author: _user,
      createdAt: DateTime.now().millisecondsSinceEpoch,
      id: const Uuid().v4(),
      text: message.text,
    );

    _addMessage(textMessage);

  final textMessageBaza = PorukaInsert(
    sadrzaj: message.text,
   korisnikId:APIService.id,
    voznjaId: widget.voznja == null? int.parse(widget.voznjaId.toString()) : widget.voznja!.id,
     username: APIService.username);
print(textMessageBaza);
var result = await APIService.Post(
        "Poruka", json.encode(textMessageBaza.toJson()).toString());
  }

  void _loadMessages() async {
    // final response = await rootBundle.loadString('assets/messages.json');
    Map<String, String> params;
     if (APIService.roleId == 3){
      params = {
        'korisnikId': APIService.id.toString(),
        'korisnikUsername':widget.usernameSearch,
        'voznjaId': 0.toString(),
        'chatovi': false.toString(),
      };
    var fromApiResponse=await APIService.Get("Poruka", params) ;
    if(fromApiResponse != null){

    var _poruke = List<PorukaInsert>.from(
        fromApiResponse.map((model) => PorukaInsert.fromJson(model)));
    List<types.Message> messages=[];
    for (var i = 0; i < _poruke.length; i++) {
   print(_poruke[i].username);

     var _user =  types.User(id: _poruke[i].korisnikId.toString());
      var m=new types.TextMessage(author: _user, id: _poruke[i].voznjaId.toString(), text: _poruke[i].username +": " + _poruke[i].sadrzaj);
      messages.insert(0, m);
    }
    setState(() {
      _messages = messages;
    });
    }
    }else if (APIService.roleId == 2){
      params = {
        'korisnikUsername': widget.usernameSearch,
        'vozacId': APIService.id.toString(),
        'voznjaId': widget.voznjaId.toString(),
      };
      print("Poruke get "+params.toString());
    var fromApiResponse=await APIService.Get("Poruka", params) ;
    
    if(fromApiResponse != null){
    var _poruke = List<PorukaInsert>.from(
        fromApiResponse.map((model) => PorukaInsert.fromJson(model)));
   
    List<types.Message> messages=[];
    for (var i = 0; i < _poruke.length; i++) {
     var _user =  types.User(id: _poruke[i].korisnikId.toString());
     print(_poruke[i].korisnikId);
      var m=new types.TextMessage(author: _user, id: _poruke[i].voznjaId.toString(), text: (APIService.id ==_poruke[i].korisnikId ? _poruke[i].vozacusername : _poruke[i].username)! +": " + _poruke[i].sadrzaj);
      messages.insert(0, m);
    }
    setState(() {
      _messages = messages;
    });
    }
    }
  
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        bottom: false,
        child: Chat(
          messages: _messages,
          onMessageTap: _handleMessageTap,
          onSendPressed: _handleSendPressed,
          user: _user,
          showUserNames: true,
        ),
      ),
    );
  }
}