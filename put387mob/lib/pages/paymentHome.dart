import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_chat_ui/flutter_chat_ui.dart';
import 'package:http/http.dart';
import 'package:put387/models/grad_model.dart';
import 'package:put387/models/profil_model.dart';
import 'package:put387/models/vozilo_model.dart';
import 'package:put387/pages/Dojam.dart';
import 'package:put387/services/APIService.dart';

class payment extends StatefulWidget {
  @override
  _paymentState createState() => _paymentState();
}

class _paymentState extends State<payment> {
 

  @override
  initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    ThemeData theme = Theme.of(context);
    return Scaffold(
        appBar: AppBar(
            title: Text('Home'),
        ),
        body: Container(
            padding: EdgeInsets.all(23),
            child: ListView.separated(
            itemBuilder: (context, index) {
                Icon icon;
                Text text;
                
                        icon = Icon(Icons.credit_card, color: Colors.green);
                        text = Text('CHOOSE CARD');                

                return InkWell(
                    onTap: () {
                        onItemPress(context, index); //called to select the function to call depending on the method chosen
                    },
                    child: ListTile(
                        title: text,
                        leading: icon,
                    ),
                );
            },
            separatorBuilder: (context, index) => Divider(
                color: Colors.green,
            ),
            itemCount: 2),
        ),
    );
  }
onItemPress(BuildContext context, int index) async {
    
        Navigator.pushNamed(context, '/cards'); //calls the list of cards screen
  
  }
}