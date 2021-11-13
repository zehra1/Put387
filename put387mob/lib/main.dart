import 'dart:io';
import 'package:flutter/material.dart';
import 'package:put387/pages/Chat.dart';
import 'package:put387/pages/DetaljiVoznje.dart';
import 'package:put387/pages/NovaVoznja.dart';
import 'package:put387/pages/Poruke.dart';
import 'dart:convert';
import 'package:put387/pages/cards.dart';
import 'pages/Home.dart';
import 'pages/Login.dart';
import 'pages/Profil.dart';
import 'pages/Zahtjevi.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home:Login(),
      routes: {
        // '/loading':(context)=>Loading(),
        '/home':(context)=>Home(),
        '/zahtjevi':(context)=>Zahtjevi(),
        '/poruke':(context)=>Chat(),
        '/profil':(context)=>Profil(),
        '/novavoznja':(context)=>NovaVoznja(),
        // '/orders':(context)=>Orders()
      },
    );
  }
}

