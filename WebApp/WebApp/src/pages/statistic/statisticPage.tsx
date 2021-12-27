import { Filters } from './filters/filters';
import { ChartLayout } from './chart/chartLayout';
import './statisticPage.scss';
import { StatisticsProvider } from '../../modules/Statistic/hooks/context/statisticProvider';

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
