import { Filters } from './filters/filters';
import { StatisticsProvider } from '../../modules/Statistic/hooks/context/statisticProvider';
import { ChartLayout } from './chart/chartLayout';
import './statisticPage.scss'

export function StatisticPage() {
    return (
        <StatisticsProvider>
            <div className={'statistic-page'}>
                <Filters/>
                <ChartLayout/>
            </div>
        </StatisticsProvider>
    );
}
