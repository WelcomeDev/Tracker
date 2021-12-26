import { Filters } from './filters/filters';
import { StatisticsProvider } from '../../modules/Statistic/hooks/context/statisticProvider';

export function StatisticPage() {

    return (
        <StatisticsProvider>
           <Filters/>
        </StatisticsProvider>
    );
}
