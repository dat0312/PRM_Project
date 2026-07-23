import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/login.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/grade_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/teacher_grade_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/request_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/schedule_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/club_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/event_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/help_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/notification_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/profile_screen.dart';

import 'dart:async';
import 'package:myfschoolse1915/vn/edu/fpt/controller/notification_controller.dart';

class HomeScreen extends StatefulWidget {
  final LoginModel user;
  const HomeScreen({super.key, required this.user});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  int _currentIndex = 1;
  late List<Widget> _screens;
  
  final NotificationController _notifController = NotificationController();
  int _unreadCount = 0;
  Timer? _timer;

  @override
  void initState() {
    super.initState();
    _screens = [
      NotificationScreen(user: widget.user),
      _HomeMainContent(user: widget.user),
      ProfileScreen(user: widget.user),
    ];
    _fetchUnreadCount();
    _timer = Timer.periodic(const Duration(seconds: 10), (timer) {
      _fetchUnreadCount();
    });
  }

  @override
  void dispose() {
    _timer?.cancel();
    super.dispose();
  }

  Future<void> _fetchUnreadCount() async {
    final notifs = await _notifController.fetchNotifications(widget.user.token);
    if (mounted) {
      setState(() {
        _unreadCount = notifs.where((n) => !n.isRead).length;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: IndexedStack(
        index: _currentIndex,
        children: _screens,
      ),
      bottomNavigationBar: Container(
        decoration: BoxDecoration(
          color: Colors.white,
          boxShadow: [
            BoxShadow(color: Colors.black.withOpacity(0.05), blurRadius: 10, offset: const Offset(0, -5))
          ],
        ),
        child: BottomNavigationBar(
          elevation: 0,
          backgroundColor: Colors.transparent,
          selectedItemColor: Colors.orange,
          unselectedItemColor: Colors.grey,
          currentIndex: _currentIndex,
          onTap: (index) {
            setState(() {
              _currentIndex = index;
            });
            if (index == 0) {
              _fetchUnreadCount();
            }
          },
          items: [
            BottomNavigationBarItem(
              icon: Badge(
                isLabelVisible: _unreadCount > 0,
                label: Text('$_unreadCount'),
                child: const Icon(Icons.notifications_none_rounded),
              ),
              activeIcon: Badge(
                isLabelVisible: _unreadCount > 0,
                label: Text('$_unreadCount'),
                child: const Icon(Icons.notifications_rounded),
              ),
              label: 'Thông báo'
            ),
            const BottomNavigationBarItem(
              icon: Icon(Icons.home_outlined), 
              activeIcon: Icon(Icons.home_rounded),
              label: 'Trang chủ'
            ),
            const BottomNavigationBarItem(
              icon: Icon(Icons.person_outline_rounded), 
              activeIcon: Icon(Icons.person_rounded),
              label: 'Cá nhân'
            ),
          ],
        ),
      ),
    );
  }
}

class _HomeMainContent extends StatelessWidget {
  final LoginModel user;
  const _HomeMainContent({required this.user});

  void _handleLogout(BuildContext context) {
    Navigator.pushAndRemoveUntil(
      context,
      MaterialPageRoute(builder: (context) => const LoginScreen()),
      (route) => false,
    );
  }

  void _navigateTo(BuildContext context, String title) {
    if (title == 'Lịch học') {
      Navigator.push(context, MaterialPageRoute(builder: (context) => ScheduleScreen(user: user)));
    } else if (title == 'Bảng điểm') {
      if (user.roles.contains("Teacher")) {
        Navigator.push(context, MaterialPageRoute(builder: (context) => TeacherGradeScreen(user: user)));
      } else {
        Navigator.push(context, MaterialPageRoute(builder: (context) => GradeScreen(user: user)));
      }
    } else if (title == 'Đơn từ') {
      Navigator.push(context, MaterialPageRoute(builder: (context) => RequestScreen(user: user)));
    } else if (title == 'Câu lạc bộ') {
      Navigator.push(context, MaterialPageRoute(builder: (context) => ClubScreen(user: user)));
    } else if (title == 'Sự kiện') {
      Navigator.push(context, MaterialPageRoute(builder: (context) => const EventScreen()));
    } else if (title == 'Trợ giúp') {
      Navigator.push(context, MaterialPageRoute(builder: (context) => const HelpScreen()));
    }
  }

  @override
  Widget build(BuildContext context) {
    List<Map<String, dynamic>> menuItems = [
      {'title': 'Bảng điểm', 'icon': Icons.assignment_rounded, 'color': Colors.amber.shade700},
      {'title': 'Lịch học', 'icon': Icons.menu_book_rounded, 'color': Colors.blue.shade600},
    ];

    if (user.roles.contains('Student') || user.roles.contains('Parent')) {
      // Cả Phụ huynh và Học sinh đều có phần 'Đơn từ'
      menuItems.insert(1, {'title': 'Đơn từ', 'icon': Icons.edit_document, 'color': Colors.red.shade600});
      
      // Câu lạc bộ chỉ dành cho học sinh, phụ huynh không có
      if (user.roles.contains('Student')) {
        menuItems.add({'title': 'Câu lạc bộ', 'icon': Icons.groups_rounded, 'color': Colors.orange.shade700});
      }

      menuItems.addAll([
        {'title': 'Sự kiện', 'icon': Icons.campaign_rounded, 'color': Colors.green.shade600},
        {'title': 'Trợ giúp', 'icon': Icons.support_agent_rounded, 'color': Colors.purple.shade600},
      ]);
    }

    return Column(
      children: [
        // --- 1. Header with Gradient ---
        Container(
          width: double.infinity,
          padding: const EdgeInsets.fromLTRB(20, 60, 20, 30),
          decoration: BoxDecoration(
            gradient: const LinearGradient(
              colors: [Color(0xFFFF9800), Color(0xFFF57C00)],
              begin: Alignment.topLeft,
              end: Alignment.bottomRight,
            ),
            borderRadius: const BorderRadius.only(
              bottomLeft: Radius.circular(32),
              bottomRight: Radius.circular(32),
            ),
            boxShadow: [
              BoxShadow(
                color: Colors.orange.withOpacity(0.3),
                blurRadius: 12,
                offset: const Offset(0, 8),
              )
            ],
          ),
          child: Row(
            children: [
              Container(
                padding: const EdgeInsets.all(2),
                decoration: const BoxDecoration(color: Colors.white, shape: BoxShape.circle),
                child: const CircleAvatar(
                  radius: 30,
                  backgroundColor: Color(0xFFF2F2F2),
                  child: Icon(Icons.person, size: 35, color: Colors.grey),
                ),
              ),
              const SizedBox(width: 16),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text("Xin chào,", style: TextStyle(color: Colors.white70, fontSize: 14)),
                    Text(
                      user.fullName,
                      style: const TextStyle(color: Colors.white, fontSize: 18, fontWeight: FontWeight.bold),
                    ),
                    const SizedBox(height: 4),
                    Text(
                      user.roles.contains('Teacher')
                          ? (user.studentId.isNotEmpty ? user.studentId : 'Chưa cập nhật mã')
                          : "Lớp: ${user.className.isNotEmpty ? user.className : '...'}  •  MSHS: ${user.studentId.isNotEmpty ? user.studentId : '...'}",
                      style: const TextStyle(color: Colors.white, fontSize: 12),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),

        // --- 2. Menu Grid ---
        Expanded(
          child: GridView.builder(
            padding: const EdgeInsets.all(20),
            itemCount: menuItems.length,
            gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
              crossAxisCount: 2,
              mainAxisSpacing: 16,
              crossAxisSpacing: 16,
              childAspectRatio: 1.1,
            ),
            itemBuilder: (context, index) {
              final item = menuItems[index];
              return InkWell(
                onTap: () => _navigateTo(context, item['title'] as String),
                borderRadius: BorderRadius.circular(20),
                child: Container(
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(20),
                    boxShadow: [
                      BoxShadow(
                        color: Colors.black.withOpacity(0.04),
                        blurRadius: 10,
                        offset: const Offset(0, 4),
                      )
                    ],
                  ),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Container(
                        padding: const EdgeInsets.all(12),
                        decoration: BoxDecoration(
                          color: item['color'].withOpacity(0.1),
                          shape: BoxShape.circle,
                        ),
                        child: Icon(item['icon'], color: item['color'], size: 30),
                      ),
                      const SizedBox(height: 12),
                      Text(
                        item['title'],
                        style: const TextStyle(
                          fontSize: 14,
                          fontWeight: FontWeight.w600,
                          color: Color(0xFF333333),
                        ),
                      ),
                    ],
                  ),
                ),
              );
            },
          ),
        ),
      ],
    );
  }
}
