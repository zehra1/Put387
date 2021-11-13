import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_chat_ui/flutter_chat_ui.dart';
import 'package:http/http.dart';
import 'package:put387/models/grad_model.dart';
import 'package:put387/models/profil_model.dart';
import 'package:put387/models/vozilo_model.dart';
import 'package:put387/pages/Dojam.dart';
import 'package:put387/services/APIService.dart';

import 'KorisnikDojmovi.dart';
import 'Login.dart';

class Profil extends StatefulWidget {
  @override
  _ProfilState createState() => _ProfilState();
}

class _ProfilState extends State<Profil> {
  ProfilDetails _userDetails = new ProfilDetails();
  Vozilo _vozilo = new Vozilo();
  List<Grad> _gradovi = [];
  int gradSelected = 1;
  bool isDirty = false;
  bool isVoziloDirty = false;
  String proizvodjac = "Proizvodjac";
  String tipGoriva = "Tip goriva";
  TextEditingController telefonController = new TextEditingController();
  TextEditingController imePrezimeController = new TextEditingController();
  TextEditingController emailController = new TextEditingController();
  TextEditingController usernameController = new TextEditingController();
  TextEditingController datumController = new TextEditingController();
  TextEditingController registracijaController = new TextEditingController();
  getData() async {
    var userDetails = await APIService.GetById("Korisnik", APIService.id);
    var gradovi = await APIService.Get("Grad", null);
    _gradovi = List<Grad>.from(gradovi!.map((model) => Grad.fromJson(model)));
    if(APIService.roleId == 2 ) {
      var vozilo = await APIService.GetById("Vozilo", APIService.id);
      _vozilo = Vozilo.fromJson(vozilo);

    }
    _userDetails = ProfilDetails.fromJson(userDetails);
    if (!isDirty && !isVoziloDirty) {
      print(isDirty);
      gradSelected = _userDetails.gradId;
      proizvodjac = _vozilo.proizvodjac;
      tipGoriva = _vozilo.tipGoriva;

      telefonController.text = _userDetails.telefon;
      usernameController.text = _userDetails.username;
      imePrezimeController.text = _userDetails.ime + " " + _userDetails.prezime;
      emailController.text = _userDetails.email;
      datumController.text = _userDetails.datumRegistracije.substring(0, 10);
      registracijaController.text = _vozilo.registracija;
    }
    // telefonController.text=_userDetails!.telefon;
    return _userDetails;
  }

  updateData() async {
    print("uslo u update");

    ProfilDetailsEdit req = new ProfilDetailsEdit(
        gradId: gradSelected, telefon: telefonController.text, userEdit: true);
    var result = await APIService.Put(
        "Korisnik", _userDetails.id, json.encode(req.toJson()).toString());

    if (isVoziloDirty) {
      Vozilo edit = new Vozilo(
          korisnikId: APIService.id,
          model: _vozilo.model,
          proizvodjac: proizvodjac,
          tipGoriva: tipGoriva,
          registracija: registracijaController.text);
      var voziloresult = await APIService.Put(
          "Vozilo", _vozilo.id, json.encode(edit.toJson()).toString());
    }
    if (result == 200) {
      isDirty = false;
      isVoziloDirty = false;
      ScaffoldMessenger.of(context)
        ..removeCurrentSnackBar()
        ..showSnackBar(SnackBar(content: Text("Podaci uspjesno izmjenjeni.")));
        Navigator.pushNamed(context, '/profil');
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
          title: Text('Profil'),
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
        body: APIService.roleId == 2 ? forma() : korisnik());
  }

  Widget forma() {
    return (FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            return CircularProgressIndicator();
          }
          _userDetails = snapshot.data;

          // gradSelected=_userDetails.gradId;

          return SingleChildScrollView(
            
            child: Column(
              children: <Widget>[
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [Text("Detalji korisnika", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),)],
                ),
                ListTile(
                  leading: const Icon(Icons.person),
                  title: const Text('Ime i prezime'),
                  subtitle: Text(imePrezimeController.text),
                ),
                new ListTile(
                  leading: const Icon(Icons.phone),
                  title: new TextField(
                    onSubmitted: (value) {
                      setState(() {
                        isDirty = true;
                        telefonController.text = value.toString();
                      });
                    },
                    controller: telefonController,
                    decoration: new InputDecoration(
                      hintText: "Telefon",
                    ),
                  ),
                ),
                
                ListTile(
                  leading: const Icon(Icons.email),
                  title: const Text('Email'),
                  subtitle: Text(emailController.text),
                ),

                const Divider(
                  height: 1.0,
                ),
                new ListTile(
                  leading: const Icon(Icons.label),
                  title: const Text('Username'),
                  subtitle: Text(usernameController.text),
                ),
                new ListTile(
                  leading: const Icon(Icons.today),
                  title: const Text('Datum registracije'),
                  subtitle: Text(datumController.text),
                ),
                new ListTile(
                  leading: const Icon(Icons.location_city),
                  subtitle: Container(
                    padding: EdgeInsets.only(
                      right: 40.0,
                    ),
                    child: DropdownButton(
                      value: gradSelected,
                      onChanged: (value) async {
                        setState(() {
                          isDirty = true;
                          gradSelected = int.parse(value.toString());
                        });
                      },
                      items: _gradovi.map((e) {
                        return DropdownMenuItem(
                            value: e.id, child: Text(e.naziv));
                      }).toList(),
                    ),
                  ),
                  title: Text("Grad"),
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [Text("Vozilo", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),)],
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: [
                    DropdownButton(
                        // hint: Text("Izaberi broj mjesta"),
                        value: proizvodjac,
                        onChanged: (value) async {
                          setState(() {
                            proizvodjac = value.toString();
                            isVoziloDirty = true;
                          });
                        },
                        items: <String>[
                          'Proizvodjac',
                          'Audi',
                          'BMW',
                          'Tesla',
                          'Golf'
                        ].map((e) {
                          return DropdownMenuItem(value: e, child: Text(e));
                        }).toList()),
                    DropdownButton(
                        // hint: Text("Izaberi broj mjesta"),
                        value: tipGoriva,
                        onChanged: (value) async {
                          setState(() {
                            tipGoriva = value.toString();
                            isVoziloDirty = true;
                          });
                        },
                        items: <String>[
                          'Tip goriva',
                          'Dizel',
                          'Benzin',
                          'Hibrid',
                        ].map((e) {
                          return DropdownMenuItem(value: e, child: Text(e));
                        }).toList()),
                  ],
                ),
                Column(
                  children: [
                    ListTile(
                      leading: const Icon(Icons.pin),
                      title: new TextField(
                        onChanged: (value) {
                          isVoziloDirty = true;
                        },
                        controller: registracijaController,
                        decoration:
                            new InputDecoration(hintText: "Broj registracije"),
                      ),
                    ),
                  ],
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextButton(
                      onPressed: isDirty || isVoziloDirty ? updateData : null,
                      child: Text(
                        "Spasi",
                      ),
                      style: TextButton.styleFrom(
                          elevation: 3.0,
                          shape: RoundedRectangleBorder(
                              borderRadius: new BorderRadius.circular(5.0)),
                          padding: EdgeInsets.symmetric(
                              vertical: 10, horizontal: 20),
                          backgroundColor: isDirty || isVoziloDirty
                              ? Color(0xffffd700)
                              : Colors.grey[300]),
                    ),
                  ],
                ),
              ],
            ),
          );
        }));
  }

  Widget korisnik() {
    return (FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            return CircularProgressIndicator();
          }
          _userDetails = snapshot.data;

          // gradSelected=_userDetails.gradId;

          return SingleChildScrollView(
            child: Column(
              children: <Widget>[
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [Text("Detalji korisnika", style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),)],
                ),
                 ListTile(
                  leading: const Icon(Icons.person),
                  title: const Text('Ime i prezime'),
                  subtitle: Text(imePrezimeController.text),
                ),
                new ListTile(
                  leading: const Icon(Icons.phone),
                  title: new TextField(
                    onSubmitted: (value) {
                      setState(() {
                        isDirty = true;
                        telefonController.text = value.toString();
                      });
                    },
                    controller: telefonController,
                    decoration: new InputDecoration(
                      hintText: "Telefon",
                    ),
                  ),
                ),
                 ListTile(
                  leading: const Icon(Icons.email),
                  title: const Text('Email'),
                  subtitle: Text(emailController.text),
                ),
                const Divider(
                  height: 1.0,
                ),
                new ListTile(
                  leading: const Icon(Icons.label),
                  title: const Text('Username'),
                  subtitle: Text(usernameController.text),
                ),
                new ListTile(
                  leading: const Icon(Icons.today),
                  title: const Text('Datum registracije'),
                  subtitle: Text(datumController.text),
                ),
                new ListTile(
                  leading: const Icon(Icons.location_city),
                  subtitle: Container(
                    padding: EdgeInsets.only(
                      right: 40.0,
                    ),
                    child: DropdownButton(
                      value: gradSelected,
                      onChanged: (value) async {
                        setState(() {
                          isDirty = true;
                          gradSelected = int.parse(value.toString());
                        });
                      },
                      items: _gradovi.map((e) {
                        return DropdownMenuItem(
                            value: e.id, child: Text(e.naziv));
                      }).toList(),
                    ),
                  ),
                  title: Text("Grad"),
                ),
                                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextButton(
                      onPressed: isDirty || isVoziloDirty ? updateData : null,
                      child: Text(
                        "Spasi",
                      ),
                      style: TextButton.styleFrom(
                          elevation: 3.0,
                          shape: RoundedRectangleBorder(
                              borderRadius: new BorderRadius.circular(5.0)),
                          padding: EdgeInsets.symmetric(
                              vertical: 10, horizontal: 20),
                          backgroundColor: isDirty || isVoziloDirty
                              ? Color(0xffffd700)
                              : Colors.grey[300]),
                    ),
                  ],
                ),
              ],
            ),
          );
        }));
  }
}
