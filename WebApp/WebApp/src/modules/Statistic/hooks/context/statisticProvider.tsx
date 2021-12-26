import { createContext, ReactNode, useContext, useEffect, useMemo } from 'react';
import { StatisticStore } from '../../store/statisticStore';
import { observer } from 'mobx-react';

const statisticContext = createContext<StatisticStore | null>(null);

export function useStatisticStore() {
    const context = useContext(statisticContext);
    if (!context) throw new Error('useStatisticStore must be used only inside StatisticsProvider');

    return context;
}

export const StatisticsProvider = observer(({ children }: { children: ReactNode }) => {

    const store = useMemo(() => new StatisticStore(), []);

    useEffect(
        () => {
            store.getTags();
        }, []);

    useEffect(
        () => {
            store.getStatistic({tagName: 'Expenses', from: '2021-12-20', to: '2021-12-27'})
        }, [],
    );

    return (
        <statisticContext.Provider
            value={store}
        >
            {children}
        </statisticContext.Provider>
    );
});