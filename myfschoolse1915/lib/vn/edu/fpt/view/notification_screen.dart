import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/notification_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/notification_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/schedule_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/club_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/request_screen.dart';

class NotificationScreen extends StatefulWidget {
  final LoginModel user;
  const NotificationScreen({Key? key, required this.user}) : super(key: key);

  @override
  _NotificationScreenState createState() => _NotificationScreenState();
}

class _NotificationScreenState extends State<NotificationScreen> {
  final NotificationController _controller = NotificationController();
  List<NotificationModel> _notifications = [];
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    _fetchNotifications();
  }

  Future<void> _fetchNotifications() async {
    setState(() => _isLoading = true);
    final notifications = await _controller.fetchNotifications(widget.user.token);
    setState(() {
      _notifications = notifications;
      _isLoading = false;
    });
  }

  Future<void> _markAsRead(NotificationModel notification) async {
    if (!notification.isRead) {
      bool success = await _controller.markAsRead(widget.user.token, notification.id);
      if (success) {
        setState(() {
          _notifications = _notifications.map((n) {
            if (n.id == notification.id) {
              return NotificationModel(
                id: n.id,
                userId: n.userId,
                title: n.title,
                message: n.message,
                isRead: true,
                createdAt: n.createdAt,
                relatedRequestId: n.relatedRequestId,
              );
            }
            return n;
          }).toList();
        });
      }
    }
    
    // Navigate to ClubScreen if it's a club notification
    if (notification.title.contains('CLB') || notification.title.contains('Câu lạc bộ')) {
      Navigator.push(context, MaterialPageRoute(builder: (context) => ClubScreen(user: widget.user)));
      return;
    }

    // Navigate to Request screen if it's a request/message
    if (notification.title.contains('Đơn') || notification.title.contains('Tin nhắn')) {
      Navigator.push(context, MaterialPageRoute(builder: (context) => RequestScreen(user: widget.user)));
      return;
    }

    // Default fallback
    if (Navigator.canPop(context)) {
      Navigator.pop(context, true); // Return true to refresh parent screens
    } else {
      Navigator.push(context, MaterialPageRoute(builder: (context) => ScheduleScreen(user: widget.user)));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Thông báo'),
        backgroundColor: Colors.blueAccent,
        foregroundColor: Colors.white,
      ),
      body: _isLoading
          ? const Center(child: CircularProgressIndicator())
          : _notifications.isEmpty
              ? const Center(child: Text('Không có thông báo nào.'))
              : ListView.builder(
                  itemCount: _notifications.length,
                  itemBuilder: (context, index) {
                    final n = _notifications[index];
                    return Card(
                      color: n.isRead ? Colors.white : Colors.blue.shade50,
                      margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
                      child: ListTile(
                        leading: Icon(
                          n.isRead ? Icons.notifications_none : Icons.notifications_active,
                          color: n.isRead ? Colors.grey : Colors.blueAccent,
                        ),
                        title: Text(n.title, style: TextStyle(fontWeight: n.isRead ? FontWeight.normal : FontWeight.bold)),
                        subtitle: Text(n.message),
                        onTap: () => _markAsRead(n),
                      ),
                    );
                  },
                ),
    );
  }
}
