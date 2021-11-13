import 'package:flutter/cupertino.dart';
import 'package:put387/services/APIService.dart';

class Voznja {
  int id;
  String polaziste;
  String odrediste;
  String vozac;
  String datumPolaska;
  int cijena;
  int vozacId;
  int brojSlobodnihMjesta;
  String? napomena;

  Voznja(
      {required this.id,
      required this.polaziste,
      required this.odrediste,
      required this.vozac,
      required this.datumPolaska,
      required this.vozacId,
      this.cijena = 0,
      required this.brojSlobodnihMjesta,
      this.napomena = "Nema napomene"});

  factory Voznja.fromJson(Map<String, dynamic> json) {
    return Voznja(
        id: json['id'],
        polaziste: json['polaziste']['naziv'],
        odrediste: json['odrediste']['naziv'],
        vozac: json['vozac']['username'],
        datumPolaska: json['datumVrijemePolaska'],
        cijena: json['cijena'],
        brojSlobodnihMjesta: json['brojSlobodnihMjesta'],
        napomena: json['napomena'],
        vozacId: json['vozacId']);
  }
}

class VoznjaInsert {
  int vozacId;
  int polaziste;
  int odrediste;
  int tipVoznje;
  String datumPolaska;
  int cijena;
  int brojSlobodnihMjesta;
  String? napomena;

  VoznjaInsert(
      {required this.polaziste,
      required this.tipVoznje,
      required this.odrediste,
      required this.datumPolaska,
      this.cijena = 0,
      this.brojSlobodnihMjesta = 4,
      required this.vozacId,
      this.napomena = "Nema napomene"});

       Map<String, dynamic> toJson() => {
        "vozacId": APIService.id,
        "polazisteId": polaziste,
        "odredisteId": odrediste,
        "tipVoznjeId": tipVoznje,
        "datumVrijemePolaska":datumPolaska,
        "brojSlobodnihMjesta": brojSlobodnihMjesta,
        "napomena": napomena,
        "aktivna": true,
        "cijena": cijena,
      };
}
