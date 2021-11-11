import 'package:flutter/material.dart';
import 'package:flutter_credit_card/credit_card_widget.dart';
import 'package:put387/services/APIService.dart';
import 'package:put387/services/service.dart';

import 'package:stripe_payment/stripe_payment.dart';

class ExistingCardsPage extends StatefulWidget {
  int cijena;
  ExistingCardsPage({Key? key,required this.cijena}) : super(key: key);

  @override
  ExistingCardsPageState createState() => ExistingCardsPageState();
}

class ExistingCardsPageState extends State<ExistingCardsPage> {
  List cards = [
    {
      'cardNumber': '4242424242424242',
      'expiryDate': '04/24',
      'cardHolderName': APIService.username,
      'cvvCode': '424',
      'showBackView': false,
    }
  ];

  payViaExistingCard(BuildContext context, card) async {
    var expiryArr = card['expiryDate'].split('/');
    CreditCard stripeCard = CreditCard(
      number: card['cardNumber'],
      expMonth: int.parse(expiryArr[0]),
      expYear: int.parse(expiryArr[1]),
    );
    var response =
        await StripeService.payWithNewCard(amount: widget.cijena.toString(), currency: 'BAM');
    Scaffold.of(context)
        .showSnackBar(SnackBar(
          content: Text("Uspjesno ste platili " + widget.cijena.toString() + "KM"),
          duration: new Duration(milliseconds: 1200),
        ))
        .closed
        .then((_) {
      // Navigator.pop(context);
      Navigator.pushNamed(context, '/zahtjevi');
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('CHOOSE CARD'),
      ),
      body: Container(
        padding: EdgeInsets.all(20),
        child: ListView.builder(
          shrinkWrap: false,
          itemCount: cards.length,
          itemBuilder: (BuildContext context, int index) {
            var card = cards[0];
            return InkWell(
              onTap: () {
                payViaExistingCard(context, cards[0]);
              },
              child: CreditCardWidget(
                cardNumber: card['cardNumber'],
                expiryDate: card['expiryDate'],
                cardHolderName: card['cardHolderName'],
                cvvCode: card['cvvCode'],
                showBackView: false, onCreditCardWidgetChange: (CreditCardBrand ) {  },
              ),
            );
          },
        )
      ),
    );
  }
}