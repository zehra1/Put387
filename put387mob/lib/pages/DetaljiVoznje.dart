import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:put387/models/voznje_model.dart';
import 'package:put387/models/zahtjev-model.dart';
import 'package:put387/pages/korisnikDojmovi.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';

import 'Poruke.dart';

class DetaljiVoznje extends StatefulWidget {
  Voznja voznja;
  String izabranBrojSjedista = "Izaberi broj mjesta";

  DetaljiVoznje({Key? key, required this.voznja}) : super(key: key);
  @override
  _DetaljiVoznjeState createState() => _DetaljiVoznjeState();
}

class _DetaljiVoznjeState extends State<DetaljiVoznje> {
  List<Voznja> _voznje = [];
  @override
  initState() {
    super.initState();
  }

  Future<int> rezervisi() async {
    Zahtjev req = new Zahtjev(
        voznjaId: widget.voznja.id,
        korisnikId: APIService.id,
        brojMjesta: int.parse(widget.izabranBrojSjedista),
        status: false);
    var result =
        await APIService.Post("Zahtjev", json.encode(req.toJson()).toString());
    return result;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Detalji voznje'),
          backgroundColor: Color(0xffffd700),
        ),
        body: Container(
          margin: const EdgeInsets.all(20),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                children: [
                  Text(widget.voznja.vozac),
                  TextButton(
                      onPressed: () {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => KorisnikDojmovi(
                                    vozacId: widget.voznja.vozacId)));
                      },
                      child: Icon(Icons.reviews)),
                  APIService.roleId == 2 && APIService.id==widget.voznja.vozacId? Text("") : TextButton(
                      onPressed: () {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => ChatPage(
                                      voznja: widget.voznja,
                                      usernameSearch: '',
                                    )));
                      },
                      child: Icon(Icons.message)),
                ],
              ),
              Card(
                child: ListTile(
                  title: Text(widget.voznja.polaziste +
                      " - " +
                      widget.voznja.odrediste),
                  subtitle: Text("Broj slobodnih mjesta " +
                      widget.voznja.brojSlobodnihMjesta.toString()),
                ),
              ),
              Text("Napomena: " +
                  (widget.voznja.napomena == null
                      ? "Nema napomene"
                      : widget.voznja.napomena.toString())),
              if(APIService.roleId == 3)DropdownButton(
                hint: Text("Izaberi broj mjesta"),
                value: widget.izabranBrojSjedista,
                onChanged: (value) async {
                  setState(() {
                    widget.izabranBrojSjedista = value.toString();
                  });
                },
                items: <String>['Izaberi broj mjesta', '1', '2', '3', '4']
                    .map((e) {
                      return DropdownMenuItem(value: e, child: Text(e));
                    })
                    .toList()
                    .sublist(0, widget.voznja.brojSlobodnihMjesta + 1),
              ),
              // Text(widget.izabranBrojSjedista.toString())
              if(APIService.roleId == 3)TextButton(
                  child: Text("Rezervisi voznju"),
                  onPressed: () {
                    if (widget.izabranBrojSjedista.length > 1) {
                      ModalHelper.showMessage(
                          context, "Greska", "Izaberi broj sjedista", "OK", () {
                        Navigator.of(context).pop();
                      });
                      return;
                    } else {
                      rezervisi().then((value) => value == 200
                          ? ModalHelper.showMessage(
                              context,
                              "Poruka",
                              "Vas zahtjev je kreiran, pricekajte odobrenje!",
                              "OK", () {
                              Navigator.of(context).pop();
                            })
                          : ModalHelper.showMessage(context, "Poruka",
                              "Vas zahtjev nije kreiran!", "OK", () {
                              Navigator.of(context).pop();
                            }));
                    }
                  }),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text("Preporučene vožnje"),
                ],
              ),
              recommededVoznje()
            ],
          ),
        ));
  }

  Widget recommededVoznje() {
    return FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            if (snapshot.connectionState == ConnectionState.done) {
              _voznje = [];
            }
            return CircularProgressIndicator();
          }
          _voznje = snapshot.data;
          return Container(
            child: _voznje.length == 0
                ? Text("Nema podataka...")
                : Expanded(
                    child: ListView.builder(
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
                                  crossAxisAlignment: CrossAxisAlignment.start,
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
                                        style: TextStyle(color: Colors.white)),
                                    style: TextButton.styleFrom(
                                        elevation: 3.0,
                                        shape: RoundedRectangleBorder(
                                            borderRadius:
                                                new BorderRadius.circular(5.0)),
                                        padding: EdgeInsets.symmetric(
                                            vertical: 10, horizontal: 20),
                                        backgroundColor: Color(0xffffd700)),
                                    onPressed: () {
                                      Navigator.push(
                                          context,
                                          MaterialPageRoute(
                                              builder: (context) =>
                                                  DetaljiVoznje(
                                                    voznja: _voznje[index],
                                                  )));
                                    }),
                              ),
                            ),
                          );
                        })),
          );
        });
  }

  getData() async {
    Map<String, String> params;
    params = {'korisnikId': widget.voznja.vozacId.toString()};
    var voznje = await APIService.Get("Recommend", params);
    _voznje = List<Voznja>.from(voznje!.map((model) => Voznja.fromJson(model)));
    return _voznje;
  }
}
