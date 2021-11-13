import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:flinq/flinq.dart';
import 'package:put387/models/poruke_model.dart';
import 'package:put387/models/zahtjev-model.dart';
import 'package:put387/pages/Dojam.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';

import 'KorisnikDojmovi.dart';
import 'Login.dart';
import 'Poruke.dart';
import 'Profil.dart';

class Chat extends StatefulWidget {
  @override
  _ChatState createState() => _ChatState();
}

class _ChatState extends State<Chat> {
  List<DistinctPoruke> _chatovi = [];
  getData() async {
    Map<String, String> params;
    if (APIService.roleId == 2)
      params = {
        'vozacId': APIService.id.toString(),
        'korisnikId': 0.toString(),
        'chatovi':true.toString()
      };
    else {
      params = {
        'korisnikId': APIService.id.toString(),
        'vozacId': 0.toString(),
        'chatovi':true.toString()
      };
    }
    var chats = await APIService.Get("Poruka", params);
    _chatovi = List<DistinctPoruke>.from(
        chats!.map((model) => DistinctPoruke.fromJson(model)));
  print("porukee "+_chatovi.toString());
    return _chatovi;
  }



  updateBrojMjesta(ZahtjevStore zahtjev) async {
    ZahtjevEdit req = new ZahtjevEdit(
        editBrojMjesta: "yes",
        brojSlobodnihMjesta: zahtjev.brojMjesta); //zapravo voznja edit
    var result = await APIService.Put(
        "Voznja", zahtjev.voznjaId, json.encode(req.toJson()).toString());
    print(json.encode(req.toJson()).toString());
    Zahtjev zahtjevReq = new Zahtjev(
        voznjaId: zahtjev.voznjaId,
        korisnikId: zahtjev.korisnikId,
        brojMjesta: zahtjev.brojMjesta,
        status: true);
    var zahtjevUpdate = await APIService.Put(
        "Zahtjev", zahtjev.id, json.encode(zahtjevReq.toJson()).toString());
    // Navigator.pop(context);
    // Navigator.pushNamed(context, "zahtjevi");
    return result;
  }

  @override
  initState() {
    getData();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    getData();
    return Scaffold(
        appBar: AppBar(
          title: Text('Zahtjevi'),
          backgroundColor: Color(0xffffd700),
        ),
        drawer: Drawer(
        child: ListView(
          children: [
            DrawerHeader(
              child: Center(
                  child: Text(
                    "Dobro dosli "+
                APIService.username,
                style: TextStyle(fontSize: 20, color: Colors.white),
              )),
              decoration: BoxDecoration(color: Color(0xffffd700)),
            ),
            ListTile(
              title: Text('Pocetna'),
              onTap: () {
                Navigator.of(context).pushNamed('/home');
              },
            ),
            if(APIService.roleId==2)
            ListTile(
              title: Text('Poruke'),
              onTap: () {
                Navigator.of(context).pushNamed('/poruke');
              },
            ),
            ListTile(
              title: Text('Zahtjevi'),
              onTap: () {
                Navigator.of(context).pushNamed('/zahtjevi');
              },
            ),
            if(APIService.roleId==2)
            ListTile(
              title: Text('Dojmovi'),
              onTap: () {
                Navigator.push(context, MaterialPageRoute(builder: (context)=>KorisnikDojmovi(vozacId:APIService.id)));

              },
            ), ListTile(
              title: Text('Profil'),
              onTap: () {
                Navigator.push(context, MaterialPageRoute(builder: (context)=>Profil()));

              },
            ),
             ListTile(
              title: Text('Log out'),
              onTap: () {
                APIService.roleId = 0;
                APIService.username = '';
                APIService.password = '';
                Navigator.push(context, MaterialPageRoute(builder: (context)=>Login()));

              },
            )
          ],
        ),
      ),
        body: vozacZahtjevi());
  }

  Widget vozacZahtjevi() {
    return (FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            if (snapshot.connectionState == ConnectionState.done) {
              _chatovi = [];
            }
            return CircularProgressIndicator();
          }

          _chatovi = snapshot.data;
          return Container(
            child: _chatovi.length == 0
                ? Text("Nema podataka...")
                : Column(
                    children: [
                      Text("Vozac zahtjevi"),
                      ListView.builder(
                          shrinkWrap: true,
                          itemCount: _chatovi[0].distinctUsers.length,
                          itemBuilder: (context, index) {
                            return Padding(
                              padding: const EdgeInsets.symmetric(
                                  vertical: 2.0, horizontal: 10.0),
                              child: Card(
                                child: ListTile(
                                  contentPadding: EdgeInsets.symmetric(
                                      vertical: 10.0, horizontal: 10.0),
                                  onTap: () {
                          Navigator.push(context, MaterialPageRoute(builder: (context)=>ChatPage(usernameId:APIService.roleId==3?APIService.id.toString(): _chatovi[0].userIds![index],voznjaId: APIService.roleId==2? _chatovi[0].voznjes![index]:"",usernameSearch: _chatovi[0].distinctUsers[index].toString(),)));

                                  },
                                  title: Padding(
                                      padding:
                                          EdgeInsets.symmetric(vertical: 10.0),
                                      child: Text(
                                          _chatovi[0].distinctUsers[index],
                                          style: TextStyle(fontSize: 20))),
                                  
                                  trailing: Container(
                                      child: TextButton(
                                          child: Icon(Icons.close),
                                          style: TextButton.styleFrom(),
                                          onPressed: () {})),
                                ),
                              ),
                            );
                          }),
                    ],
                  ),
          );
        })
        );
  }

}