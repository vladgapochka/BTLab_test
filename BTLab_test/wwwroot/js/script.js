$(document).ready(function () {
    $('#calendar').fullCalendar({
        defaultView: 'month',
        events: [
            {
                title: 'Отпуск',
                start: '2024-02-15',
                end: '2024-02-22'
            },
            {
                title: 'Больничный',
                start: '2024-02-25',
                end: '2024-02-28'
            }
        ]
    });
});