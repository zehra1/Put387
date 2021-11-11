import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:put387/models/dojam_model.dart';
import 'package:put387/models/voznje_model.dart';
import 'package:put387/models/zahtjev-model.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class Dojam extends StatefulWidget {
  // rating
  late final _ratingController;
  late double _rating=2.0;
  double _userRating = 3.0;
  int _ratingBarMode = 1;
  double _initialRating = 2.0;
  bool _isRTLMode = false;
  bool _isVertical = false;
  // end

  int voznjaId;
  int zahtjevId;
  TextEditingController komentarController = new TextEditingController();
  Dojam({Key? key, required this.voznjaId,required this.zahtjevId}) : super(key: key);
  @override
  _DojamState createState() => _DojamState();
}

class _DojamState extends State<Dojam> {
  @override
  initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Dojam za odabranu voznju'),
          backgroundColor: Color(0xffffd700),
        ),
        body: formaDojam());
  }

  Widget formaDojam() {
    return Container(
      padding: EdgeInsets.symmetric(vertical: 10, horizontal: 20),
      margin: EdgeInsets.symmetric(vertical: 15, horizontal: 20),
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(20),
          color: Colors.white,
          boxShadow: [
            BoxShadow(
                color: Theme.of(context).hintColor.withOpacity(0.2),
                offset: Offset(0, 10),
                blurRadius: 10)
          ]),
      child: (Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Padding(padding: EdgeInsets.all(30)),
          Text(
            "Vas komentar",
            style: TextStyle(fontSize: 20, fontWeight: FontWeight.w600),
          ),
          TextField(
            controller: widget.komentarController,
            keyboardType: TextInputType.multiline,
            maxLines: null,
          ),
          Padding(padding: EdgeInsets.all(10)),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("Ocjenite voznju  "),
              Icon(Icons.sentiment_satisfied_alt)
            ],
          ),
          Padding(padding: EdgeInsets.all(10)),
          _ratingBar(1),
          Padding(padding: EdgeInsets.all(20)),
          TextButton(
              onPressed: () {
                snimiDojam().then((value) =>
                    value == 200 ?
                     Navigator.pop(context,200) 
                    :"Nije");
              },
              child: Text("Spasi",
            style: TextStyle(fontSize: 20)
              ),
              style: TextButton.styleFrom(
                primary: Colors.white,
                backgroundColor: Color(0xffffd700),
                onSurface: Colors.grey,
                padding: EdgeInsets.fromLTRB(20, 10, 20, 10),
              )),
        ],
      )),
    );
  }

  Future<int> snimiDojam() async {
    int ocj = widget._rating.toInt();
    DojamInsert noviDojam = new DojamInsert(
        voznjaId: widget.voznjaId,
        ocjena: ocj,
        komentar: widget.komentarController.text,
        korisnikId: APIService.id,
        zahtjevId:widget.zahtjevId);
    var result = await APIService.Post(
        "VoznjaDojam", json.encode(noviDojam.toJson()).toString());
    return result;
  }

  Widget _ratingBar(int mode) {
    switch (mode) {
      case 1:
        return RatingBar.builder(
          initialRating: widget._initialRating,
          minRating: 1,
          direction: Axis.horizontal,
          allowHalfRating: true,
          unratedColor: Colors.amber.withAlpha(50),
          itemCount: 5,
          itemSize: 25.0,
          itemPadding: EdgeInsets.symmetric(horizontal: 4.0),
          itemBuilder: (context, _) => Icon(
            Icons.star,
            color: Colors.amber,
          ),
          onRatingUpdate: (rating) {
            setState(() {
              widget._rating = rating;
            });
          },
          updateOnDrag: true,
        );
      default:
        return Container();
    }
  }
}
