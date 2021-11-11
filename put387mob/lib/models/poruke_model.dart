class PorukaInsert {
  String sadrzaj;
  int korisnikId;
  int? voznjaId;
  String username;
  String? vozacusername;
  String? datumVrijemeKreiranja;
  List<String>? distinctUsers;
  
  PorukaInsert({required this.sadrzaj, required this.korisnikId, this.voznjaId,required this.username, this.datumVrijemeKreiranja, this.distinctUsers, this.vozacusername});
  Map<String, dynamic> toJson() => {
        'sadrzaj': sadrzaj,
        'korisnikId': korisnikId,
        'voznjaId': voznjaId

      };

        factory PorukaInsert.fromJson(Map<String, dynamic> json) {
    return PorukaInsert(
        sadrzaj: json['sadrzaj'],
        voznjaId: json['voznjaId'],
        korisnikId: json['korisnikId'],
        username: json['korisnik']['username'],
        datumVrijemeKreiranja: json['datumVrijemeKreiranja'],
        distinctUsers:json['usernames'],
        vozacusername:json['voznja']['vozac']['username']
        );
  }

}



class DistinctPoruke {
  List<dynamic> distinctUsers;
  List<dynamic>? voznjes;
  List<dynamic>? userIds;
  
  DistinctPoruke({required this.distinctUsers,  this.voznjes,  this.userIds});
        factory DistinctPoruke.fromJson(Map<String, dynamic> json) {
    return DistinctPoruke(
        distinctUsers:json['usernames'],
        voznjes:json['voznjes'],
        userIds:json['usernameIds'],

        );
  }

}
