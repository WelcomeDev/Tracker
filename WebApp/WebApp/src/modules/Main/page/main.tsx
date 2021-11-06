import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Header } from "./header/header";
import { appRoutes } from "../../../config/appRoutes";
import { Pomodoro } from "../../Pomodoros/page/pomodoro";
import { Statistic } from "../../Statistic/page/statistic";

const { pomodoro, statistic } = appRoutes;

export function Main() {
    return (
        <BrowserRouter>
            <Header/>
            <Routes>
                <Route path={pomodoro} element={<Pomodoro/>}/>
                <Route path={statistic} element={<Statistic/>}/>
            </Routes>
        </BrowserRouter>
    )
}
