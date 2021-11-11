class DojamInsert {
  int voznjaId;
  int ocjena;
  String komentar;
  int korisnikId;
  int zahtjevId;

  DojamInsert({required this.voznjaId, required this.ocjena, required this.komentar,required this.korisnikId,required this.zahtjevId});
  Map<String, dynamic> toJson() => {
        'voznjaId': voznjaId,
        'ocjena': ocjena,
        'komentar': komentar,
        'korisnikId': korisnikId,
        'zahtjevId': zahtjevId,
      };
}

class DojamStore{
  String vozacUsername;
  int ocjena;
  String komentar;
  String koriniskUsername;
  String datumKreiranja;

  DojamStore({required this.vozacUsername, required this.ocjena, required this.komentar,required this.koriniskUsername,required this.datumKreiranja});
          factory DojamStore.fromJson(Map<String, dynamic> json) {
    return DojamStore(
        vozacUsername: json['voznja']['vozac']['username'],
        ocjena: json['ocjena'],
        komentar: json['komentar'],
        koriniskUsername: json['korisnik']['username'],
        datumKreiranja: json['datumKreiranja'],
        );
  }
}
