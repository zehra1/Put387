import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:put387/models/voznje_model.dart';
import 'package:put387/pages/DetaljiVoznje.dart';
import 'package:put387/pages/KorisnikDojmovi.dart';
import 'package:put387/pages/Login.dart';
import 'package:put387/pages/paymentHome.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';

import 'Profil.dart';

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  List<Voznja> _voznje = [];
  List<Voznja> _voznjefil = [];
  bool flag = false;
  DateTime? startDate = DateTime.now();
  DateTime? endDate = DateTime.now();
  getData() async {
    var voznje = await APIService.Get("Voznja", null);
    _voznje = List<Voznja>.from(voznje!.map((model) => Voznja.fromJson(model)));
    return _voznje;
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
        title: Text('Nadolazece voznje'),
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
              if(APIService.roleId==2) ListTile(
              title: Text('Dodaj voznju'),
              onTap: () {
                Navigator.of(context).pushNamed('/novavoznja');
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
      body: Column(
        children: [
          Card(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                Icon(Icons.date_range),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text("Od:"),
                        TextButton(
                          style: ButtonStyle(
                              backgroundColor:
                                  MaterialStateProperty.all(Color(0xffffd700))),
                          child: Text(startDate.toString().substring(0, 10)),
                          onPressed: () {
                            showDatePicker(
                                    context: context,
                                    initialDate: DateTime.now(),
                                    firstDate: DateTime(2020),
                                    lastDate: DateTime(2022))
                                .then((value) => setState(() {
                                      if(value==null)
                                        startDate=DateTime.now();
                                      else
                                      startDate = value;
                                    }));
                          },
                        ),
                      ],
                    ),
                  ],
                ),
                Column(
                  children: [
                    Column(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        Icon(Icons.date_range),
                      ],
                    ),
                    Text("Do:"),
                    TextButton(
                      child: Text(endDate.toString().substring(0, 10)),
                      onPressed: () {
                        showDatePicker(
                                context: context,
                                initialDate: DateTime.now(),
                                firstDate: DateTime(2020),
                                lastDate: DateTime(2022))
                            .then((value) => setState(() {
                                  if(value==null)
                                        endDate=DateTime.now();
                                      else
                                      endDate = value;
                                }));
                      },
                    ),
                  ],
                )
              ],
            ),
          ),
          Row(
            children: [
              Column(
                children: [
                  TextButton(
                      child: Text("Pretrazi"),
                      onPressed: () async {
                        if(endDate!.isBefore(startDate!)){
                          ModalHelper.showMessage(context, "Poruka",
                              "Provjeri datume!", "OK", () {
                              Navigator.of(context).pop();
                            });
                        }else{

                        Map<String, String> queryParams;
                        queryParams = {
                          'OdDatuma': startDate.toString(),
                          'DoDatuma': endDate.toString()
                        };
                        List? result =
                            await APIService.Get('Voznja', queryParams);
                        print(result?.length);
                        setState(() {
                          _voznjefil = List<Voznja>.from(
                              result!.map((model) => Voznja.fromJson(model)));
                          flag = true;
                        });
                        }
                      }
                      )
                ],
              )
            ],
          ),
          FutureBuilder(
              future:
                  getData(), //async function that returns a Future<Map<String, dynamic>>
              builder: (BuildContext context, AsyncSnapshot snapshot) {
                if (!snapshot.hasData) {
                  if (snapshot.connectionState == ConnectionState.done) {
                    _voznje = [];
                  }
                  return CircularProgressIndicator();
                }
                if (flag) {
                  print("flag" + flag.toString());
                  _voznje = _voznjefil;
                } else
                  _voznje = snapshot.data;
                return Container(
                  child: _voznje.length == 0
                      ? Text("Nema podataka...")
                      : Expanded(child:ListView.builder(
                          shrinkWrap: true,
                          itemCount: _voznje.length,
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
                                          _voznje[index].polaziste +
                                              " - " +
                                              _voznje[index].odrediste,
                                          style: TextStyle(fontSize: 20))),
                                  subtitle: Column(
                                    crossAxisAlignment:
                                        CrossAxisAlignment.start,
                                    children: [
                                      Text(_voznje[index].vozac,
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold)),
                                      Text(DateUtils.dateOnly(DateTime.parse(
                                              _voznje[index].datumPolaska))
                                          .toString()
                                          .substring(0, 16))
                                    ],
                                  ),
                                  leading: Column(
                                    mainAxisAlignment: MainAxisAlignment.center,
                                    children: [
                                      Icon(Icons.place),
                                    ],
                                  ),
                                  trailing: TextButton(
                                      child: Text("Detalji",
                                          style:
                                              TextStyle(color: Colors.white)),
                                      style: TextButton.styleFrom(
                                          elevation: 3.0,
                                          shape: RoundedRectangleBorder(
                                              borderRadius:
                                                  new BorderRadius.circular(
                                                      5.0)),
                                          padding: EdgeInsets.symmetric(
                                              vertical: 10, horizontal: 20),
                                          backgroundColor: Color(0xffffd700)),
                                      onPressed: () {
                                        Navigator.push(context, MaterialPageRoute(builder: (context)=>DetaljiVoznje(voznja: _voznje[index],)));
                                      }),
                                ),
                              ),
                            );
                          })
                          ),
                );
              }),
        ],
      ),
    );
  }
}
