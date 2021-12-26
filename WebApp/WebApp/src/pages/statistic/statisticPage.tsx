import { Filters } from './filters/filters';
import { StatisticsProvider } from '../../modules/Statistic/hooks/context/statisticProvider';
import { ChartLayout } from './chart/chartLayout';

export function StatisticPage() {
    return (
        <StatisticsProvider>
            <Filters/>
            <ChartLayout/>
        </StatisticsProvider>
    );
}
