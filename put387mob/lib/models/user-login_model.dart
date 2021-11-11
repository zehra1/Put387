class UserLogin {
  String username;
  String password;

  UserLogin({required this.username, required this.password});
  Map<String, dynamic> toJson() => {
        'username': username,
        'password': password,
      };
}