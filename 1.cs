#include <iostream>
#include <string>
#include <ctime>

std::string getSeason(int month) {
    switch (month) {
        case 12: case 1: case 2:
            return "Winter";
        case 3: case 4: case 5:
            return "Spring";
        case 6: case 7: case 8:
            return "Summer";
        case 9: case 10: case 11:
            return "Autumn";
        default:
            return "";
    }
}

std::string getDayOfWeek(int day, int month, int year) {
    std::tm time_in = { 0, 0, 0, day, month - 1, year - 1900 };
    std::time_t time_temp = std::mktime(&time_in);

    const std::tm * time_out = std::localtime(&time_temp);
    switch (time_out->tm_wday) {
        case 0: return "Sunday";
        case 1: return "Monday";
        case 2: return "Tuesday";
        case 3: return "Wednesday";
        case 4: return "Thursday";
        case 5: return "Friday";
        case 6: return "Saturday";
        default: return "";
    }
}

int main() {
    int day, month, year;
    char dot1, dot2;

    std::cout << "Введіть дату (дд.мм.рррр): ";
    std::cin >> day >> dot1 >> month >> dot2 >> year;

    if (dot1 != '.' || dot2 != '.' || day < 1 || day > 31 || month < 1 || month > 12) {
        std::cout << "Помилка: неправильний формат дати." << std::endl;
        return 1;
    }

    std::string season = getSeason(month);
    std::string dayOfWeek = getDayOfWeek(day, month, year);

    std::cout << season << " " << dayOfWeek << std::endl;

    return 0;
}
