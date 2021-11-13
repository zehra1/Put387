class Grad {
  int id;
  String naziv;

  Grad({required this.id, required this.naziv});
  Map<String, dynamic> toJson() => {
        'id': id,
        'naziv': naziv,
      };

        factory Grad.fromJson(Map<String, dynamic> json) {
    return Grad(
        id: json['id'],
        naziv: json['naziv'],

        );
  }
}