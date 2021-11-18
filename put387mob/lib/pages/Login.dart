import 'package:flutter/material.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/utils/modal_helper.dart';


class Login extends StatefulWidget {
  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController usernameController = new TextEditingController();
  TextEditingController passwordController = new TextEditingController();
  Future<bool> Login() async {
    return await APIService.Login('Korisnik/Login', usernameController.text,passwordController.text);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: ListView(
      children: [
        Padding(
          padding: EdgeInsets.all(60),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Column(
                children: [
                  Image(
                    width: 150,
                    height: 150,
                    image: AssetImage('assets/logo.jpg'),
                  ),
                  Text(
                    'Put387',
                    style: TextStyle(fontSize: 30),
                  )
                ],
              ),
              SizedBox(
                height: 20,
              ),
              TextField(
                controller: usernameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(20),),
                    hintText: 'Korisničko ime'),
              ),
              SizedBox(
                height: 20,
              ),
              TextField(
                controller: passwordController,
                obscureText: true,
                decoration: InputDecoration(
                    border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(20),),
                    focusColor: Colors.amber[700],
                    hintText: 'Šifra'),
              ),
              SizedBox(
                height: 20,
              ),
              Container(
                height: 60,
                width: 300,
                decoration: BoxDecoration(
                    color: Color(0xffffd700),
                    borderRadius: BorderRadius.circular(20)),
                child: TextButton(
                  onPressed: () async {
                    APIService.username = usernameController.text;
                    APIService.password = passwordController.text;
                    await Login().then((value) => value? 
                      Navigator.of(context).pushReplacementNamed("/home"):
                      ModalHelper.showMessage(context, "Greska", "Pogresan unos!", "OK", (){
                        Navigator.of(context).pop();
                      })
                    );
                    
                  },
                  child: Text(
                    'Login',
                    style: TextStyle(color: Colors.white, fontSize: 20),
                  ),
                ),
              )
            ],
          ),
        ),
      ],
    ));
  }
}
