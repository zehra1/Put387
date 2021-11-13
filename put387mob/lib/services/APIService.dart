import 'dart:convert';
import 'package:http/http.dart' as http;
import 'dart:io';
import 'package:put387/models/user-login_model.dart';
import 'package:put387/models/user_mode.dart';
import 'package:stripe_payment/stripe_payment.dart';

class APIService{
  static String username="";
  static String password="";
  static int id=0;
  static int roleId=0;
  static int latestRespId=0;
  static int latestRespStatus=0;
  String route;
  static String url="http://10.0.2.2:64904/api/";

  APIService({required this.route});

  void SetParameter(String Username, String Password){
    username=Username;
    password=Password;
  }

  static Future<bool> Login(String route,String requestUsername, String requestPassword) async {
    UserLogin user = new UserLogin(username: requestUsername, password: requestPassword);
    String baseUrl=url+route;
    final r = await http.post(Uri.parse(baseUrl),
        headers: {
          // 'authorization': 'Basic ' + basicAuth,
          "Content-Type": "application/json"
        },
        body: jsonEncode(user.toJson()));

  print(r.body);
    if (r.statusCode == 200) {
      var l = json.decode(r.body);
      User user=User.fromJson(l);
      roleId=user.role;
      id=user.id;
      return true;
    }
    return false;
  }

  static Future<List<dynamic>?> Get(String route, dynamic object) async{
    String queryString = Uri(queryParameters: object).query;
    String baseUrl=url+route;
    if(object!=null){
        baseUrl = baseUrl + '?' + queryString;
    }
    print(queryString);
    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response= await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader:basicAuth},

    );
    if(response.statusCode==200){
      return json.decode(response.body) as List;
    }
    return null;
  }

    static Future<int> Post(String route, String body) async {
    String baseUrl=url+route;
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: body,
    );
  
    if (response.statusCode == 200) {
      print("uspjesno");
    }else
      print("nije uspjesno");
    return response.statusCode;
  }

   static Future<int> Put(String route,int id, String body) async {
    String baseUrl=url+route+"/"+id.toString();
    final response = await http.put(
      Uri.parse(baseUrl),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: body,
    );
  
    if (response.statusCode == 200) {
      print("uspjesno");
    }else
      print("nije uspjesno");
    return response.statusCode;
  }

    static Future<dynamic?> GetById(String route,int id) async{
        String baseUrl=url+route+"/"+id.toString();

    final String basicAuth='Basic '+base64Encode(utf8.encode('$username:$password'));
    final response= await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader:basicAuth},

    );
    if(response.statusCode==200){
      return json.decode(response.body);
    }
    return null;
  }
}

