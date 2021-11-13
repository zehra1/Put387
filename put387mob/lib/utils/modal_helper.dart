import 'package:flutter/material.dart';

class ModalHelper {
  static void showMessage(
    BuildContext context,
    String title,
    String message,
    String buttonText,
    Function onPressed,
  ) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: new Text(title),
          content: new Text(message),
          actions: [
            new TextButton(
              onPressed: () {
                return onPressed();
              },
              child: new Text(buttonText),
            )
          ],
        );
      },
    );
  }
}