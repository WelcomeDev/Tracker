import { PomodoroDto } from "../model/pomodoro";

export const mockData:PomodoroDto[] = [
    {
        "user": {
            // "name": "admin",
            "id": "b41a9f1b-9c27-4985-9ba8-55d32614591d"
        },
        "title": "Work",
        "id": "7fa825a1-0309-4817-a9d1-2f75b5cce5c6",
        "restDuration": {
            "minutes": 15,
            "hours": 0
        },
        "workDuration": {
            "minutes": 15,
            "hours": 1
        }
    },
    {
        "user": {
            // "name": "admin",
            "id": "b41a9f1b-9c27-4985-9ba8-55d32614591d"
        },
        "title": "Read",
        "id": "21b4c19e-e486-4305-9c34-b9d6a728add0",
        "restDuration": {
            "minutes": 15,
            "hours": 0
        },
        "workDuration": {
            "minutes": 30,
            "hours": 0
        }
    },
    {
        "user": {
            "id": "b41a9f1b-9c27-4985-9ba8-55d32614591d"
        },
        "title": "Test",
        "id": "7fa825a1-0309-4817-a9d1-2f89b512e5c6",
        "restDuration": {
            "minutes": 2,
            "hours": 0
        },
        "workDuration": {
            "minutes": 1,
            "hours": 0
        }
    },
]
