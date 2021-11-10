import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Header } from "./header/header";
import { appRoutes } from "../../../config/appRoutes";
import { PomodoroPage } from "../../Pomodoros/page/pomodoroPage";
import { Statistic } from "../../Statistic/page/statistic";

const { pomodoro, statistic } = appRoutes;

export function Main() {
    return (
        <BrowserRouter>
            <Header/>
            <Routes>
                <Route path={pomodoro} element={<PomodoroPage/>}/>
                <Route path={statistic} element={<Statistic/>}/>
            </Routes>
        </BrowserRouter>
    )
}
