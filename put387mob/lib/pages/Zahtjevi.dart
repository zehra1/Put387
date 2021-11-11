import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:put387/models/voznje_model.dart';
import 'package:put387/models/zahtjev-model.dart';
import 'package:put387/pages/Dojam.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';

import 'KorisnikDojmovi.dart';
import 'Login.dart';
import 'Profil.dart';
import 'cards.dart';

class Zahtjevi extends StatefulWidget {
  @override
  _ZahtjeviState createState() => _ZahtjeviState();
}

class _ZahtjeviState extends State<Zahtjevi> {
  List<ZahtjevStore> _zahtjevi = [];
  // List<Voznja> _voznjefil = [];
  // bool flag = false;
  // DateTime? startDate = DateTime.now();
  // DateTime? endDate = DateTime.now();
  getData() async {
    print(APIService.id.toString());
    Map<String, String> params;
    if (APIService.roleId == 2)
      params = {
        'vozacId': APIService.id.toString(),
        'korisnikId': 0.toString()
      };
    else {
      params = {
        'korisnikId': APIService.id.toString(),
        'vozacId': 0.toString()
      };
    }
    var zahtjevi = await APIService.Get("Zahtjev", params);
    _zahtjevi = List<ZahtjevStore>.from(
        zahtjevi!.map((model) => ZahtjevStore.fromJson(model)));
    _zahtjevi = APIService.roleId == 2
        ? _zahtjevi.where((e) => !e.status).toList()
        : _zahtjevi.toList();
    return _zahtjevi;
  }

  void _navigateAndDisplaySelection(
      BuildContext context, int voznjaid, int zahtjevId) async {
    // Navigator.push returns a Future that completes after calling
    // Navigator.pop on the Selection Screen.
    final result = await Navigator.push(
      context,
      MaterialPageRoute(
          builder: (context) => Dojam(
                voznjaId: voznjaid,
                zahtjevId: zahtjevId,
              )),
    );

    // After the Selection Screen returns a result, hide any previous snackbars
    // and show the new result.
    if (int.parse('$result') == 200) {
      print("poruka");
      ScaffoldMessenger.of(context)
        ..removeCurrentSnackBar()
        ..showSnackBar(SnackBar(content: Text("Hvala na dojmu!")));
      setState(() {});
    }
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
        body: APIService.roleId == 2 ? vozacZahtjevi() : putnikZahtjevi());
  }

  Widget vozacZahtjevi() {
    return (FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            if (snapshot.connectionState == ConnectionState.done) {
              _zahtjevi = [];
            }
            return CircularProgressIndicator();
          }

          _zahtjevi = snapshot.data;
          return Container(
            padding: EdgeInsets.all(10),
            child: _zahtjevi.length == 0
                ? Text("Korisnik nema aktivnih zahtjeva...")
                :Column(
                  children: [
                    Expanded(child:ListView.builder(
                              shrinkWrap: true,
                              itemCount: _zahtjevi.length,
                              itemBuilder: (context, index) {
                                return Padding(
                                  padding: const EdgeInsets.symmetric(
                                      vertical: 2.0, horizontal: 10.0),
                                  child: Card(
                                    child: ListTile(
                                      contentPadding: EdgeInsets.symmetric(
                                          vertical: 10.0, horizontal: 10.0),
                                      onTap: () {},
                                      title: Padding(
                                          padding:
                                              EdgeInsets.symmetric(vertical: 10.0),
                                          child: Text(
                                               _zahtjevi[index].polaziste +
                                              " - " +
                                              _zahtjevi[index].odrediste,
                                              style: TextStyle(fontSize: 20))),
                                      subtitle: Column(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.start,
                                        children: [
                                          Text(
                                              "br mjesta: " +
                                                  _zahtjevi[index]
                                                      .brojMjesta.toString(),
                                              style: TextStyle(
                                                  fontWeight: FontWeight.bold)),
                                          Text(DateUtils.dateOnly(DateTime.parse(
                                                  _zahtjevi[index].datumKreiranja))
                                              .toString()
                                              .substring(0, 16))
                                        ],
                                      ),
                                     leading: TextButton(
                                      child: Icon(Icons.check),
                                      style: TextButton.styleFrom(),
                                      onPressed: () {
                                        updateBrojMjesta(_zahtjevi[index]);
                                      }),
                                      trailing: Container(
                                      child: TextButton(
                                          child: Icon(Icons.close),
                                          style: TextButton.styleFrom(),
                                          onPressed: () {})),
                                    ),
                                  ),
                                );
                              })),
                  ],
                ),
                    
                  
          );
        })
        );
  }

  Widget putnikZahtjevi() {
    return (FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            if (snapshot.connectionState == ConnectionState.done) {
              _zahtjevi = [];
            }
            return CircularProgressIndicator();
          }

          _zahtjevi = snapshot.data;
          return Container(
            child: _zahtjevi.length == 0
                ? Text("Nema podataka...")
                : Column(
                    children: [
                      Text("Putnik zahtjevi"),
                     Expanded(child: ListView.builder(
                          shrinkWrap: true,
                          itemCount: _zahtjevi.length,
                          itemBuilder: (context, index) {
                            return Padding(
                              padding: const EdgeInsets.symmetric(
                                  vertical: 2.0, horizontal: 10.0),
                              child: Card(
                                child: ListTile(
                                  contentPadding: EdgeInsets.symmetric(
                                      vertical: 10.0, horizontal: 10.0),
                                  onTap: () {},
                                  title: Padding(
                                      padding:
                                          EdgeInsets.symmetric(vertical: 10.0),
                                      child: Text(
                                          _zahtjevi[index].polaziste +
                                              " - " +
                                              _zahtjevi[index].odrediste,
                                          style: TextStyle(fontSize: 20))),
                                  subtitle: Column(
                                    crossAxisAlignment:
                                        CrossAxisAlignment.start,
                                    children: [
                                      Text(
                                          "BrMjesta " +
                                              _zahtjevi[index]
                                                  .brojMjesta
                                                  .toString(),
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold)),
                                      Text(DateUtils.dateOnly(DateTime.parse(
                                              _zahtjevi[index].datumKreiranja))
                                          .toString()
                                          .substring(0, 16))
                                    ],
                                  ),
                                  leading: TextButton(
                                      child: Icon(Icons.location_city),
                                      style: TextButton.styleFrom(),
                                      onPressed: () {}),
                                  trailing: Column(
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      children: [
                                        !_zahtjevi[index].isReviewed
                                            ? !_zahtjevi[index].status
                                                ? Text("Na cekanju",
                                                    style: TextStyle(
                                                        color:
                                                            Colors.orange[600]))
                                                : _zahtjevi[index].isPaid ? TextButton(
                                                    onPressed: () {
                                                      _navigateAndDisplaySelection(
                                                          context,
                                                          _zahtjevi[index]
                                                              .voznjaId,
                                                          _zahtjevi[index].id);
                                                    },
                                                    child: Text(
                                                      "Ostavi dojam",style: TextStyle(
                                                        color:
                                                            Colors.white),
                                                    ),
                                                    style: ButtonStyle(backgroundColor: MaterialStateProperty.all(Colors.orange[400])),
                                                  ) : TextButton(onPressed: () async {
                                                      // Navigator.pushNamed(context, '/cards');
                                                       Navigator.push(context, MaterialPageRoute(builder: (context)=>ExistingCardsPage(cijena: _zahtjevi[index].cijena,)));
                                                     ZahtjevEdit req = new ZahtjevEdit(
        editBrojMjesta: "yes",
        brojSlobodnihMjesta: 2,
        onlyPay: true); //zapravo voznja edit
    var result = await APIService.Put(
        "Zahtjev",_zahtjevi[index].id, json.encode(req.pay()).toString());

                                                    
                                                    }, child: Text("Plati "+ _zahtjevi[index].cijena.toString()+"KM"))
                                            : Text("Zavrseno",
                                                    style: TextStyle(
                                                        color:
                                                            Colors.green[600]))
                                      ]),
                                ),
                              ),
                            );
                          })),
                    ],
                  ),
          );
        }));
  }
}
