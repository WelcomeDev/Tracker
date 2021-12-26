import { createRef, useMemo } from 'react';
import { Chart } from 'chart.js';
import moment from 'moment';
import { observer } from 'mobx-react';
import { StatisticStore } from '../../../modules/Statistic/store/statisticStore';
import { Loader } from '../../components/loader/loader';

export const ChartLayout = observer(() => {

    const store = useMemo(() => new StatisticStore(), []);
    const canvas = createRef<HTMLCanvasElement>();

    if (!store.items)
        return <Loader/>;

    const myChart = new Chart(canvas.current as HTMLCanvasElement, {
        type: 'bar',
        data: {
            labels: store.items.dates.map(x => moment(x)
                .format('DD\nMM')),
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

    return (
        <canvas
            ref={canvas}
            id={'statisticChart'}>
        </canvas>
    );
});