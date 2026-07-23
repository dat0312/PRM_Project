import 'package:flutter/material.dart';

class GlobalState {
  static final ValueNotifier<String> searchQuery = ValueNotifier<String>('');
}
