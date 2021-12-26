import { createRef, useEffect } from 'react';
import Chart from 'chart.js/auto'
import moment from 'moment';
import { observer } from 'mobx-react';
import { StatisticStore } from '../../../modules/Statistic/store/statisticStore';
import { Loader } from '../../components/loader/loader';
import { useStatisticStore } from '../../../modules/Statistic/hooks/context/statisticProvider';

export const ChartLayout = observer(() => {

    const store = useStatisticStore();
    const canvas = createRef<HTMLCanvasElement>();

    useEffect(
        () => {
            if (!store.items) return;

            const myChart = new Chart(canvas.current as HTMLCanvasElement, {
                type: 'bar',
                data: {
                    labels: store.items.dates.map(x => moment(x)
                        .format('DD-MM')),
                    datasets: store.items.models.map(d => ({ label: d.title, backgroundColor: d.color, data: d.values })),
                },
                options: {
                    responsive: true,
                    scales: {
                        x: {
                            stacked: true,
                        },
                        y: {
                            stacked: true,
                        },
                    },
                },
            });

            return () => {
                myChart.destroy();
            };
        },
        [store.items]);

    if (!store.items)
        return <Loader/>;

    return (
        <canvas
            ref={canvas}
            id={'statisticChart'}>
        </canvas>
    );
});