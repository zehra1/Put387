class Zahtjev {
  int voznjaId;
  int korisnikId;
  int brojMjesta;
  bool? status;
  bool? isReviewed;

  Zahtjev({required this.voznjaId, required this.korisnikId,required this.brojMjesta,this.status,this.isReviewed});
  Map<String, dynamic> toJson() => {
        'voznjaId': voznjaId,
        'korisnikId': korisnikId,
        'brojMjesta': brojMjesta,
        'status': status,
      };
}

class ZahtjevStore {
  int id;
  int voznjaId;
  int? vozacId;
  int korisnikId;
  String polaziste;
  String odrediste;
  String datumKreiranja;
  int cijena;
  String? napomena;
  int brojMjesta;
  bool status;
  bool isReviewed;
  bool isPaid;


  ZahtjevStore({required this.id,required this.voznjaId ,this.vozacId,  required this.korisnikId,required this.polaziste,required this.odrediste,required this.datumKreiranja,this.cijena=0,required this.brojMjesta,this.napomena,required this.status,required this.isReviewed,required this.isPaid});
        factory ZahtjevStore.fromJson(Map<String, dynamic> json) {
    return ZahtjevStore(
        id: json['id'],
        voznjaId: json['voznjaId'],
        polaziste: json['voznja']['polaziste']['naziv'],
        odrediste: json['voznja']['odrediste']['naziv'],
        vozacId: json['voznja']['vozacId'],
        korisnikId: json['korisnikId'],
        datumKreiranja: json['datumKreiranja'],
        cijena: json['voznja']['cijena'],
        brojMjesta: json['brojMjesta'],
        napomena:json['napomena'],
        status:json['status'],
        isReviewed:json['isReviewed'],
        isPaid:json['isPaid'],
        );
  }
}

class ZahtjevEdit {
  String editBrojMjesta="yes";
  int brojSlobodnihMjesta;
  bool? onlyPay;

  ZahtjevEdit({required this.editBrojMjesta, required this.brojSlobodnihMjesta,this.onlyPay});
  Map<String, dynamic> toJson() => {
        'editBrojMjesta': editBrojMjesta,
        'brojSlobodnihMjesta': brojSlobodnihMjesta,
        'onlyPay': onlyPay,
      };

      Map<String, dynamic> pay() => {
        'onlyPay': onlyPay,
      };
}
