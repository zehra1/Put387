class User {
  int id;
  String username;
  int role;

  User({required this.id, required this.username, required this.role});
  Map<String, dynamic> toJson() => {
        'username': username,
        'id': id,
        'ulogaId': role,
      };
  factory User.fromJson(Map<String, dynamic> json) {
    return User(
        id: json['id'],
        username: json['username'],
        role: json['ulogaId']);
  }
}
