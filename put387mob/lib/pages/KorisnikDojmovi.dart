import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:put387/models/dojam_model.dart';
import 'package:put387/models/zahtjev-model.dart';
import 'package:put387/pages/Dojam.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';

class KorisnikDojmovi extends StatefulWidget {
  int vozacId;
  KorisnikDojmovi({Key? key, required this.vozacId}) : super(key: key);
  @override
  _KorisnikDojmoviState createState() => _KorisnikDojmoviState();
}

class _KorisnikDojmoviState extends State<KorisnikDojmovi> {
  List<DojamStore> _dojmovi = [];
  getData() async {
    Map<String, String> params;
      params = {
        'vozacId': widget.vozacId.toString()
      };
    
    var dojmovi = await APIService.Get("VoznjaDojam", params);
    _dojmovi = List<DojamStore>.from(
        dojmovi!.map((model) => DojamStore.fromJson(model)));
        print(_dojmovi);
    return _dojmovi;
  }

  getPozitivne(){
    return _dojmovi.where((e) => e.ocjena>1).length;
  }

  getNegativne(){
    return _dojmovi.where((e) => e.ocjena<2).length;
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
          title: Text('Dojmovi odabranog korisnika'),
          backgroundColor: Color(0xffffd700),
        ),
        body: dojmoviKorisnika(widget.vozacId));
  }

  Widget dojmoviKorisnika(int vozacId){
    return (
      FutureBuilder(
        future:
            getData(), //async function that returns a Future<Map<String, dynamic>>
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (!snapshot.hasData) {
            if (snapshot.connectionState == ConnectionState.done) {
              _dojmovi = [];
            }
            return CircularProgressIndicator();
          }

          _dojmovi = snapshot.data;
          return Container(
            padding: EdgeInsets.all(10),
            child: _dojmovi.length == 0
                ? Text("Korisnik nema dojmova...")
                :Column(
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Column(
                          children: [
                          Text("Pozitivni",style: TextStyle(color: Colors.green,fontSize: 20)),
                          Text(getPozitivne().toString(),style: TextStyle(color: Colors.green,fontSize: 18))
                        ],),
                        Column(children: [
                          Text("Negativni",style: TextStyle(color: Colors.red,fontSize: 20)),
                          Text(getNegativne().toString(),style: TextStyle(color: Colors.red,fontSize: 18))
                        ],)
                      ],
                    ),
                    Expanded(child:ListView.builder(
                              shrinkWrap: true,
                              itemCount: _dojmovi.length,
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
                                              _dojmovi[index].koriniskUsername,
                                              style: TextStyle(fontSize: 20))),
                                      subtitle: Column(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.start,
                                        children: [
                                          Text(
                                              "Komentar: " +
                                                  _dojmovi[index].komentar,
                                              style: TextStyle(
                                                  fontWeight: FontWeight.bold)),
                                          Text(DateUtils.dateOnly(DateTime.parse(
                                                  _dojmovi[index].datumKreiranja))
                                              .toString()
                                              .substring(0, 16))
                                        ],
                                      ),
                                      leading: _dojmovi[index].ocjena>3? Icon(Icons.insert_emoticon_outlined): Icon(Icons.mood_bad_outlined),
                                      trailing: Container(
                                          child: Text(_dojmovi[index].ocjena.toString()),
                                              ),
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
}