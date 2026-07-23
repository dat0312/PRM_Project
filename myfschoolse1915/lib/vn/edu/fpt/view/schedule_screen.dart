import 'package:flutter/material.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/schedule_controller.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/schedule_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/login_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/model/schedule_request_model.dart';
import 'package:myfschoolse1915/vn/edu/fpt/view/notification_screen.dart';
import 'package:myfschoolse1915/vn/edu/fpt/controller/notification_controller.dart';
import 'dart:async';
import 'package:intl/intl.dart';


class ScheduleScreen extends StatefulWidget {
  final LoginModel user;
  const ScheduleScreen({super.key, required this.user});

  @override
  State<ScheduleScreen> createState() => _ScheduleScreenState();
}

class _ScheduleScreenState extends State<ScheduleScreen> {
  DateTime selectedDate = DateTime.now();
  String selectedSemester = "Học kỳ 1";
  bool _isLoading = true;
  List<ScheduleModel> _allSchedules = [];
  final ScheduleController _controller = ScheduleController();
  final NotificationController _notifController = NotificationController();
  final List<GlobalKey> _dayKeys = List.generate(7, (index) => GlobalKey());

  late DateTime _startOfWeek;
  late DateTime _endOfWeek;
  late List<DateTime> _weekDates;
  
  int _unreadCount = 0;
  Timer? _timer;

  @override
  void initState() {
    super.initState();
    _calculateWeekDates();
    _fetchData();
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

  void _calculateWeekDates() {
    int currentDay = selectedDate.weekday; // 1 = Monday, 7 = Sunday
    DateTime start = selectedDate.subtract(Duration(days: currentDay - 1));
    _startOfWeek = DateTime(start.year, start.month, start.day, 0, 0, 0);
    _endOfWeek = DateTime(start.year, start.month, start.day, 23, 59, 59).add(const Duration(days: 6));

    _weekDates = List.generate(7, (index) => _startOfWeek.add(Duration(days: index)));
  }

  Future<void> _fetchData() async {
    setState(() {
      _isLoading = true;
    });

    try {
      final schedules = await _controller.fetchSchedules(
        widget.user.token,
        _startOfWeek,
        _endOfWeek,
      );
      setState(() {
        _allSchedules = schedules;
        _isLoading = false;
      });
    } catch (e) {
      setState(() {
        _allSchedules = [];
        _isLoading = false;
      });
    }
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: DateTime(2020),
      lastDate: DateTime(2030),
      builder: (context, child) {
        return Theme(
          data: Theme.of(context).copyWith(
            colorScheme: const ColorScheme.light(
              primary: Colors.orange,
              onPrimary: Colors.white,
              onSurface: Colors.black,
            ),
          ),
          child: child!,
        );
      },
    );
    if (picked != null) {
      setState(() {
        selectedDate = picked;
        _calculateWeekDates();
      });
      _fetchData();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        backgroundColor: Colors.orange,
        elevation: 0,
        centerTitle: true,
        title: const Text(
          'Lịch học',
          style: TextStyle(color: Colors.black, fontWeight: FontWeight.bold, fontSize: 24),
        ),
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Colors.black),
          onPressed: () => Navigator.pop(context),
        ),
        shape: const RoundedRectangleBorder(
          borderRadius: BorderRadius.vertical(
            bottom: Radius.circular(30),
          ),
        ),
        toolbarHeight: 100,
        actions: [
          Stack(
            children: [
              IconButton(
                icon: const Icon(Icons.notifications, color: Colors.black),
                onPressed: () async {
                  await Navigator.push(context, MaterialPageRoute(builder: (context) => NotificationScreen(user: widget.user)));
                  _fetchUnreadCount();
                },
              ),
              if (_unreadCount > 0)
                Positioned(
                  right: 8,
                  top: 8,
                  child: Container(
                    padding: const EdgeInsets.all(2),
                    decoration: BoxDecoration(color: Colors.red, borderRadius: BorderRadius.circular(10)),
                    constraints: const BoxConstraints(minWidth: 16, minHeight: 16),
                    child: Text('$_unreadCount', style: const TextStyle(color: Colors.white, fontSize: 10), textAlign: TextAlign.center),
                  ),
                )
            ],
          ),
        ],
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                _buildSemesterChip("Học kỳ 1"),
                const SizedBox(width: 8),
                _buildSemesterChip("Học kỳ 2"),
              ],
            ),
            const SizedBox(height: 16),
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 8),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  IconButton(
                    icon: const Icon(Icons.arrow_left, color: Color(0xFF1A237E)),
                    onPressed: () {
                      setState(() {
                        selectedDate = selectedDate.subtract(const Duration(days: 7));
                        _calculateWeekDates();
                      });
                      _fetchData();
                    },
                  ),
                  GestureDetector(
                    onTap: () => _selectDate(context),
                    child: Text(
                      "Tháng ${selectedDate.month}, ${selectedDate.year}",
                      style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16, color: Color(0xFF1A237E)),
                    ),
                  ),
                  IconButton(
                    icon: const Icon(Icons.arrow_right, color: Color(0xFF1A237E)),
                    onPressed: () {
                      setState(() {
                        selectedDate = selectedDate.add(const Duration(days: 7));
                        _calculateWeekDates();
                      });
                      _fetchData();
                    },
                  ),
                ],
              ),
            ),
            _buildCalendarRow(),
            const Divider(height: 1),
            
            Expanded(
              child: _isLoading
                  ? const Center(child: CircularProgressIndicator(color: Colors.orange))
                  : selectedSemester == "Học kỳ 2"
                      ? const Center(child: Text("Chưa có lịch học cho học kỳ này", style: TextStyle(color: Colors.grey, fontSize: 16)))
                      : ListView(
                          padding: const EdgeInsets.symmetric(vertical: 16),
                          children: List.generate(7, (index) {
                            final date = _weekDates[index];
                            final dateString = "${date.day}/${date.month}";
                            final dayNames = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];
                            final dayName = dayNames[index];
                            final dateLabel = "$dateString $dayName";
                            
                            final daySchedules = _allSchedules.where((s) => s.dateLabel == dateLabel).toList();
                            return Container(
                              key: _dayKeys[index],
                              child: _buildDaySection(dateString, dayName, daySchedules),
                            );
                          }),
                        ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildSemesterChip(String label) {
    bool isSelected = selectedSemester == label;
    return GestureDetector(
      onTap: () {
        setState(() {
          selectedSemester = label;
        });
      },
      child: Container(
        padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 8),
        decoration: BoxDecoration(
          color: isSelected ? Colors.orange : Colors.white,
          borderRadius: BorderRadius.circular(20),
          border: Border.all(color: Colors.black),
        ),
        child: Text(
          label,
          style: TextStyle(
            color: Colors.black,
            fontWeight: isSelected ? FontWeight.bold : FontWeight.normal,
          ),
        ),
      ),
    );
  }

  Widget _buildCalendarRow() {
    final days = ["Th 2", "Th 3", "Th 4", "Th 5", "Th 6", "Th 7", "CN"];
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 12),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: List.generate(7, (index) {
          final date = _weekDates[index];
          bool isSelected = date.day == selectedDate.day && date.month == selectedDate.month && date.year == selectedDate.year;
          
          return GestureDetector(
            onTap: () {
              setState(() {
                selectedDate = date;
              });
              if (selectedSemester == "Học kỳ 1" && _dayKeys[index].currentContext != null) {
                Scrollable.ensureVisible(
                  _dayKeys[index].currentContext!,
                  duration: const Duration(milliseconds: 500),
                  curve: Curves.easeInOut,
                );
              }
            },
            child: Column(
              children: [
                Text(days[index], style: const TextStyle(color: Colors.grey, fontSize: 12)),
                const SizedBox(height: 8),
                Container(
                  padding: const EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    color: isSelected ? const Color(0xFF1A237E) : Colors.transparent,
                    shape: BoxShape.circle,
                  ),
                  child: Text(
                    "${date.day}",
                    style: TextStyle(
                      color: isSelected ? Colors.white : Colors.black,
                      fontWeight: isSelected ? FontWeight.bold : FontWeight.normal,
                    ),
                  ),
                ),
                const Icon(Icons.circle, size: 4, color: Colors.grey),
              ],
            ),
          );
        }),
      ),
    );
  }

  Widget _buildDaySection(String date, String day, List<ScheduleModel> daySchedules) {
    return Column(
      children: [
        if (daySchedules.isEmpty)
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 10),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  width: 70,
                  alignment: Alignment.topCenter,
                  child: Column(
                    children: [
                      Text(date, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
                      Text(day, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                    ],
                  ),
                ),
                Expanded(
                  child: Container(
                    height: 40,
                    margin: const EdgeInsets.only(left: 20),
                    alignment: Alignment.centerLeft,
                    child: Text("Không có tiết học", style: TextStyle(color: Colors.grey.shade400, fontSize: 13, fontStyle: FontStyle.italic)),
                  ),
                ),
              ],
            ),
          )
        else
          ...daySchedules.asMap().entries.map((entry) {
            int idx = entry.key;
            ScheduleModel schedule = entry.value;
            return _buildScheduleItem(schedule, showDate: idx == 0);
          }),
        const Divider(indent: 70, height: 1),
      ],
    );
  }

  Widget _buildScheduleItem(ScheduleModel schedule, {bool showDate = true}) {
    final dateParts = schedule.dateLabel.split(' ');
    final dateStr = dateParts.isNotEmpty ? dateParts[0] : '';
    final dayStr = dateParts.length > 1 ? dateParts[1] : '';

    return GestureDetector(
      onTap: null, // Disabled on mobile, view only
      child: IntrinsicHeight(

      child: Row(
        crossAxisAlignment: CrossAxisAlignment.stretch,
        children: [
          Container(
            width: 70,
            padding: const EdgeInsets.only(top: 10),
            child: showDate 
              ? Column(
                  children: [
                    Text(dateStr, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
                    Text(dayStr, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                  ],
                )
              : const SizedBox.shrink(),
          ),
          Column(
            children: [
              Container(
                width: 4,
                decoration: BoxDecoration(
                  color: schedule.subjectCode == "Chào cờ" ? Colors.blue : Colors.orange,
                  borderRadius: BorderRadius.circular(2),
                ),
                constraints: const BoxConstraints(minHeight: 120),
              ),
            ],
          ),
          const SizedBox(width: 16),
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  children: [
                    _buildSlotBadge(schedule.slot),
                    const SizedBox(width: 12),
                    Expanded(
                      child: Container(
                        padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 8),
                        decoration: BoxDecoration(
                          color: Colors.grey.shade100,
                          borderRadius: BorderRadius.circular(8),
                        ),
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            const Text("Phòng học", style: TextStyle(color: Colors.grey, fontSize: 11)),
                            Text(schedule.room, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16)),
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
                Padding(
                  padding: const EdgeInsets.only(left: 4, top: 4),
                  child: Row(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Column(
                        children: [
                          Text(schedule.startTime, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                          const SizedBox(height: 10),
                          const Text("|", style: TextStyle(color: Colors.grey)),
                          const SizedBox(height: 10),
                          Text(schedule.endTime, style: const TextStyle(color: Colors.grey, fontSize: 12)),
                        ],
                      ),
                      const SizedBox(width: 16),
                      Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(schedule.subjectCode, style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 15, color: Color(0xFF1A237E))),
                          Text("Lớp: ${schedule.className}", style: const TextStyle(color: Colors.grey, fontSize: 13)),
                          Text("Giáo viên: ${schedule.lecturer}", style: const TextStyle(color: Colors.grey, fontSize: 13)),
                          const SizedBox(height: 8),
                          Row(
                            children: [
                              _buildStatusBadge(schedule.status),
                              const SizedBox(width: 8),
                              _buildMaterialBadge(),
                            ],
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 15),
              ],
            ),
          ),
        ],
      ),
    ),
    );
  }

  Widget _buildSlotBadge(String slot) {
    Color color = Colors.orange.shade100;
    Color textColor = Colors.orange.shade800;
    if (slot.contains("1") || slot.contains("Chào cờ")) {
      color = Colors.blue.shade100;
      textColor = Colors.blue.shade800;
    }
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 4),
      decoration: BoxDecoration(
        color: color,
        borderRadius: BorderRadius.circular(12),
      ),
      child: Text(
        slot,
        style: TextStyle(color: textColor, fontWeight: FontWeight.bold, fontSize: 12),
      ),
    );
  }

  Widget _buildStatusBadge(String status) {
    String label = status == "PRESENT" ? "ĐÃ HỌC" : "CHƯA HỌC";
    Color color = status == "PRESENT" ? Colors.green : Colors.grey.shade400;
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
      decoration: BoxDecoration(
        color: color,
        borderRadius: BorderRadius.circular(8),
      ),
      child: Text(
        label,
        style: const TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 11),
      ),
    );
  }

  Widget _buildMaterialBadge() {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
      decoration: BoxDecoration(
        color: Colors.orange,
        borderRadius: BorderRadius.circular(8),
      ),
      child: const Text(
        "Tài liệu",
        style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 11),
      ),
    );
  }

  void _showRequestDialog(ScheduleModel schedule) {
    String selectedType = 'Leave';
    TextEditingController reasonController = TextEditingController();
    DateTime? makeUpDate;
    int? makeUpSlot;
    List<int> occupiedSlots = [];
    bool isLoadingSlots = false;
    
    showDialog(
      context: context,
      builder: (ctx) {
        return StatefulBuilder(
          builder: (context, setStateSB) {
            return AlertDialog(
              title: const Text("Yêu cầu lịch học"),
              content: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    DropdownButtonFormField<String>(
                      value: selectedType,
                      items: const [
                        DropdownMenuItem(value: 'Leave', child: Text("Báo nghỉ")),
                        DropdownMenuItem(value: 'Makeup', child: Text("Báo bù")),
                      ],
                      onChanged: (val) {
                        setStateSB(() { selectedType = val!; });
                      },
                      decoration: const InputDecoration(labelText: "Loại yêu cầu"),
                    ),
                    const SizedBox(height: 10),
                    if (selectedType == 'Makeup') ...[
                      InkWell(
                        onTap: () async {
                          final date = await showDatePicker(
                            context: context,
                            initialDate: makeUpDate ?? DateTime.now(),
                            firstDate: DateTime.now(),
                            lastDate: DateTime(2030),
                          );
                          if (date != null) {
                            setStateSB(() {
                              makeUpDate = date;
                              makeUpSlot = null;
                              isLoadingSlots = true;
                            });
                            final slots = await _controller.fetchOccupiedSlots(widget.user.token, date, schedule.classId);
                            setStateSB(() {
                              occupiedSlots = slots;
                              isLoadingSlots = false;
                            });
                          }
                        },
                        child: InputDecorator(
                          decoration: const InputDecoration(labelText: "Ngày dạy bù", border: OutlineInputBorder()),
                          child: Text(makeUpDate == null ? "Chọn ngày" : DateFormat('dd/MM/yyyy').format(makeUpDate!)),
                        ),
                      ),
                      const SizedBox(height: 10),
                      if (isLoadingSlots)
                        const CircularProgressIndicator()
                      else
                        DropdownButtonFormField<int>(
                          value: makeUpSlot,
                          decoration: const InputDecoration(labelText: "Ca học", border: OutlineInputBorder()),
                          items: List.generate(6, (i) => i + 1)
                              .where((slot) => !occupiedSlots.contains(slot))
                              .map((slot) => DropdownMenuItem(value: slot, child: Text("Slot $slot")))
                              .toList(),
                          onChanged: (val) => setStateSB(() => makeUpSlot = val),
                        ),
                      const SizedBox(height: 10),
                    ],
                    TextField(
                      controller: reasonController,
                      decoration: const InputDecoration(labelText: "Lý do", border: OutlineInputBorder()),
                      maxLines: 3,
                    ),
                  ],
                ),
              ),
              actions: [
                TextButton(onPressed: () => Navigator.pop(ctx), child: const Text("Hủy")),
                ElevatedButton(
                  onPressed: () async {
                    if (reasonController.text.isEmpty) {
                      ScaffoldMessenger.of(this.context).showSnackBar(const SnackBar(content: Text("Vui lòng nhập lý do")));
                      return;
                    }
                    if (selectedType == 'Makeup' && (makeUpDate == null || makeUpSlot == null)) {
                      ScaffoldMessenger.of(this.context).showSnackBar(const SnackBar(content: Text("Vui lòng chọn ngày và ca dạy bù")));
                      return;
                    }
                    Navigator.pop(ctx);
                    final req = ScheduleRequestModel(
                      id: 0,
                      scheduleId: schedule.id,
                      teacherId: 0, // Backend uses token
                      requestType: selectedType,
                      reason: reasonController.text,
                      requestedDate: DateTime.now().toIso8601String(),
                      status: 'Pending',
                      makeUpDate: makeUpDate?.toIso8601String(),
                      makeUpSlot: makeUpSlot,
                    );
                    bool res = await _controller.submitScheduleRequest(widget.user.token, req);
                    if (res) {
                      ScaffoldMessenger.of(this.context).showSnackBar(const SnackBar(content: Text("Gửi yêu cầu thành công")));
                    } else {
                      ScaffoldMessenger.of(this.context).showSnackBar(const SnackBar(content: Text("Gửi yêu cầu thất bại")));
                    }
                  },
                  style: ElevatedButton.styleFrom(backgroundColor: Colors.orange),
                  child: const Text("Gửi", style: TextStyle(color: Colors.white)),
                ),
              ],
            );
          }
        );
      },
    );
  }
}
