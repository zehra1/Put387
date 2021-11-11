import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_chat_ui/flutter_chat_ui.dart';
import 'package:http/http.dart';
import 'package:put387/models/mjesto.dart';
import 'package:put387/models/profil_model.dart';
import 'package:put387/models/vozilo_model.dart';
import 'package:put387/models/voznje_model.dart';
import 'package:put387/pages/Dojam.dart';
import 'package:put387/services/APIService.dart';

import 'KorisnikDojmovi.dart';
import 'Login.dart';
import 'Profil.dart';

class NovaVoznja extends StatefulWidget {
  @override
  _NovaVoznjaState createState() => _NovaVoznjaState();
}

class _NovaVoznjaState extends State<NovaVoznja> {
  List<BasicDropdown> _polazista = [];
  List<BasicDropdown> _odredista = [];
  List<BasicDropdown> _tipoviVoznje = [];
  int polazisteSelected = 1;
  int odredisteSelected = 1;
  int tipVoznjeSelected = 1;
  bool isDirty = false;
  DateTime? datumPolaska = DateTime.now();

  TextEditingController brojSlobodnihController = new TextEditingController();
  TextEditingController napomenaController = new TextEditingController();
  TextEditingController cijenaController = new TextEditingController();
  getData() async {
    var polazista = await APIService.Get("Mjesto", null);
    var odrediste = await APIService.Get("Mjesto", null);
    _polazista = List<BasicDropdown>.from(
        polazista!.map((model) => BasicDropdown.fromJson(model)));
    _odredista = List<BasicDropdown>.from(
        odrediste!.map((model) => BasicDropdown.fromJson(model)));
    
    return true;
  }

  insertData() async {

    VoznjaInsert req = new VoznjaInsert(polaziste: polazisteSelected, tipVoznje: tipVoznjeSelected, odrediste: odredisteSelected, datumPolaska: datumPolaska.toString(), napomena: napomenaController.text.length>0? napomenaController.text.toString() : "Nema napomene", cijena: cijenaController.text.length>0? int.parse(cijenaController.text.toString()) : 0, brojSlobodnihMjesta: brojSlobodnihController.text.length>0? int.parse(brojSlobodnihController.text.toString()) : 4, vozacId: APIService.id);
    print(req.toJson());
    var result = await APIService.Post("Voznja",  json.encode(req.toJson()).toString());
    print(result);
    if (result == 200) {
      isDirty = false;
      ScaffoldMessenger.of(context)
        ..removeCurrentSnackBar()
        ..showSnackBar(SnackBar(content: Text("Voznja uspjesno kreirana.")));
        Navigator.pushNamed(context, '/home');
    }
  }

  @override
  initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Dodaj voznju'),
          backgroundColor: Color(0xffffd700),
        ),
        drawer: Drawer(
          child: ListView(
            children: [
              DrawerHeader(
                child: Center(
                    child: Text(
                  "Dobro dosli " + APIService.username,
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
              if (APIService.roleId == 2)
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
              if (APIService.roleId == 2)
                ListTile(
                  title: Text('Dojmovi'),
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) =>
                                KorisnikDojmovi(vozacId: APIService.id)));
                  },
                ),
              ListTile(
                title: Text('Profil'),
                onTap: () {
                  Navigator.push(context,
                      MaterialPageRoute(builder: (context) => Profil()));
                },
              ),
              ListTile(
                title: Text('Log out'),
                onTap: () {
                  APIService.roleId = 0;
                  APIService.username = '';
                  APIService.password = '';
                  Navigator.push(context,
                      MaterialPageRoute(builder: (context) => Login()));
                },
              ),
            ],
          ),
        ),
        body: forma());
  }

  Widget forma() {
    return (FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            print(snapshot.hasData);
            return CircularProgressIndicator();
          }
          return SingleChildScrollView(
            child: Column(
              children: <Widget>[
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Text(
                      "Dodaj novu voznju",
                      style:
                          TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                    )
                  ],
                ),
                new ListTile(
                  leading: const Icon(Icons.location_city),
                  subtitle: Container(
                    padding: EdgeInsets.only(
                      right: 40.0,
                    ),
                    child: DropdownButton(
                      value: polazisteSelected,
                      onChanged: (value) async {
                        setState(() {
                          isDirty = true;
                          polazisteSelected = int.parse(value.toString());
                        });
                      },
                      items: _polazista.map((e) {
                        return DropdownMenuItem(
                            value: e.id, child: Text(e.naziv));
                      }).toList(),
                    ),
                  ),
                  title: Text("Polaziste"),
                ),
                new ListTile(
                  leading: const Icon(Icons.location_city),
                  subtitle: Container(
                    padding: EdgeInsets.only(
                      right: 40.0,
                    ),
                    child: DropdownButton(
                      value: odredisteSelected,
                      onChanged: (value) async {
                        setState(() {
                          isDirty = true;
                          odredisteSelected = int.parse(value.toString());
                        });
                      },
                      items: _odredista.map((e) {
                        return DropdownMenuItem(
                            value: e.id, child: Text(e.naziv));
                      }).toList(),
                    ),
                  ),
                  title: Text("Odrediste"),
                ),
                new ListTile(
                  leading: const Icon(Icons.location_city),
                  subtitle: Container(
                    padding: EdgeInsets.only(
                      right: 40.0,
                    ),
                    child: DropdownButton(
                        hint: Text("Izaberi tip voznje"),
                        value: tipVoznjeSelected,
                        onChanged: (value) async {
                          setState(() {
                            tipVoznjeSelected = int.parse(value.toString());
                          });
                        },
                        items: <BasicDropdown>[
                          new BasicDropdown(id: 1, naziv: "Kratka"),
                          new BasicDropdown(id: 2, naziv: "Duga")
                        ].map((e) {
                          return DropdownMenuItem(
                              value: e.id, child: Text(e.naziv));
                        }).toList()),
                  ),
                  title: Text("Tip voznje"),
                ),
                new ListTile(
                  leading: const Icon(Icons.location_city),
                  subtitle: Container(
                    padding: EdgeInsets.only(
                      right: 40.0,
                    ),
                    child: TextButton(
                      style: ButtonStyle(
                          backgroundColor:
                              MaterialStateProperty.all(Color(0xffebebeb))),
                      child: Text(datumPolaska.toString().substring(0, 10)),
                      onPressed: () {
                        showDatePicker(
                                context: context,
                                initialDate: DateTime.now(),
                                firstDate: DateTime(2020),
                                lastDate: DateTime(2022))
                            .then((value) => setState(() {
                                  if (value == null)
                                    datumPolaska = DateTime.now();
                                  else
                                    datumPolaska = value;
                                }));
                      },
                    ),
                  ),
                  title: Text("Datum polaska"),
                ),
                new ListTile(
                  leading: const Icon(Icons.phone),
                  title: new TextField(
                    keyboardType: TextInputType.number,
                    inputFormatters: <TextInputFormatter>[
                      FilteringTextInputFormatter.digitsOnly
                    ],
                    onSubmitted: (value) {
                      setState(() {
                        isDirty = true;
                        brojSlobodnihController.text = value.toString();
                      });
                    },
                    controller: brojSlobodnihController,
                    decoration: new InputDecoration(
                      hintText: "Broj slobodnih mjesta",
                    ),
                  ),
                ),
                new ListTile(
                  leading: const Icon(Icons.phone),
                  title: new TextField(
                    onSubmitted: (value) {
                      setState(() {
                        isDirty = true;
                        napomenaController.text = value.toString();
                      });
                    },
                    controller: napomenaController,
                    decoration: new InputDecoration(
                      hintText: "Napomena",
                    ),
                  ),
                ),
                new ListTile(
                  leading: const Icon(Icons.phone),
                  title: new TextField(
                    keyboardType: TextInputType.number,
                    inputFormatters: <TextInputFormatter>[
                      FilteringTextInputFormatter.digitsOnly,
                    ],
                    onSubmitted: (value) {
                      setState(() {
                        isDirty = true;
                        cijenaController.text = value.toString();
                      });
                    },
                    controller: cijenaController,
                    decoration: new InputDecoration(
                      hintText: "Cijena",
                    ),
                  ),
                  trailing: Text("KM"),
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextButton(
                      onPressed: insertData,
                      child: Text(
                        "Spasi",
                      ),
                      style: TextButton.styleFrom(
                          elevation: 3.0,
                          shape: RoundedRectangleBorder(
                              borderRadius: new BorderRadius.circular(5.0)),
                          padding: EdgeInsets.symmetric(
                              vertical: 10, horizontal: 20),
                          backgroundColor:
                              isDirty ? Color(0xffffd700) : Colors.grey[300]),
                    ),
                  ],
                ),
              ],
            ),
          );
        }));
  }
}
