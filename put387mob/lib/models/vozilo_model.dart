class Vozilo {
  int id = 0;
  String tipGoriva = '';
  int korisnikId = 0;
  String proizvodjac = '';
  String registracija = '';
  String model = '';


  Vozilo(
      {this.id = 0,
      this.tipGoriva = "",
      this.proizvodjac = "",
      this.registracija = "",
      this.model = "",
      this.korisnikId = 0,
      });

  factory Vozilo.fromJson(Map<String, dynamic> json) {
    return Vozilo(
        id: json['id'],
        tipGoriva: json['tipGoriva'],
        korisnikId: json['korisnikId'],
        proizvodjac: json['proizvodjac'],
        model: json['model'],
        registracija: json['brojRegistracije'],
       );
  }

    Map<String, dynamic> toJson() => {
        'korisnikId': korisnikId,
        'tipGoriva': tipGoriva,
        'proizvodjac': proizvodjac,
        'model': model,
        'brojRegistracije': registracija,
      };
}

class VoziloEdit {
  int gradId = 0;
  String telefon = '';
  bool userEdit=true;
  VoziloEdit({required this.gradId, required this.telefon,required this.userEdit});

  Map<String, dynamic> toJson() => {
        'telefon': telefon,
        'gradId': gradId,
        'userEdit': userEdit,
      };
}
