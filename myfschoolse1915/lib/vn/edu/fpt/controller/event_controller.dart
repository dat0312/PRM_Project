import 'package:myfschoolse1915/vn/edu/fpt/model/event_model.dart';

class EventController {
  final List<EventModel> _mockEvents = [
    EventModel(
      title: "FPT Tech Day 2026",
      date: "15/07/2026",
      location: "Hội trường Delta",
      description: "Ngày hội công nghệ lớn nhất trong năm.",
    ),
    EventModel(
      title: "Giải bóng đá sinh viên",
      date: "20/06/2026",
      location: "Sân bóng FPT",
      description: "Khai mạc giải bóng đá tranh cúp FPT.",
    ),
  ];

  List<EventModel> getEvents() => _mockEvents;
}
