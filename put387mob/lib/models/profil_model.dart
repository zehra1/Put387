class ProfilDetails {
  int id = 0;
  String ime = '';
  String prezime = '';
  String email = '';
  String username = '';
  String telefon = '';
  String ulogaNaziv = '';
  String grad = '';
  String datumRegistracije = '';
  int gradId = 0;

  ProfilDetails(
      {this.id = 0,
      this.ime = "",
      this.prezime = "",
      this.email = "",
      this.username = "",
      this.telefon = "",
      this.ulogaNaziv = "",
      this.grad = "",
      this.gradId = 0,
      this.datumRegistracije = ""});

  factory ProfilDetails.fromJson(Map<String, dynamic> json) {
    return ProfilDetails(
        id: json['id'],
        ime: json['ime'],
        prezime: json['prezime'],
        email: json['email'],
        username: json['username'],
        telefon: json['telefon'],
        ulogaNaziv: json['uloga']['naziv'],
        grad: json['grad']['naziv'],
        gradId: json['grad']['id'],
        datumRegistracije: json['datumRegistracije']);
  }
}

class ProfilDetailsEdit {
  int gradId = 0;
  String telefon = '';
  bool userEdit=true;
  ProfilDetailsEdit({required this.gradId, required this.telefon,required this.userEdit});

  Map<String, dynamic> toJson() => {
        'telefon': telefon,
        'gradId': gradId,
        'userEdit': userEdit,
      };
}
