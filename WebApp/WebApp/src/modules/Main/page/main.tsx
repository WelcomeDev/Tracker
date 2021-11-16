import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Header } from "./header/header";
import { appRoutes } from "../../../config/appRoutes";
import { PomodoroPage } from "../../Pomodoros/page/pomodoroPage";
import { Statistic } from "../../Statistic/page/statistic";
import './main.scss';
import classNames from "classnames";

const { pomodoro, statistic } = appRoutes;

export function Main() {
    return (
        <BrowserRouter>
            <div className={'app-wrapper'}>
                <Header className={'header'}/>
                <div className={classNames('content-container','page-content')}>
                    <Routes>
                        <Route path={pomodoro} element={<PomodoroPage/>}/>
                        <Route path={statistic} element={<Statistic/>}/>
                    </Routes>
                </div>
            </div>
        </BrowserRouter>
    )
}
