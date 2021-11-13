class BasicDropdown {
  int id;
  String naziv;

  BasicDropdown({required this.id, required this.naziv});
  Map<String, dynamic> toJson() => {
        'id': id,
        'naziv': naziv,
      };

        factory BasicDropdown.fromJson(Map<String, dynamic> json) {
    return BasicDropdown(
        id: json['id'],
        naziv: json['naziv'],

        );
  }
}