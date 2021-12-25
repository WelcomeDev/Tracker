import { createRef } from 'react';
import { Chart } from 'chart.js';
import { Statistic } from '../../../modules/Statistic/model/statistic';

// import Chart from 'chartjs';

export function ChartLayout() {

    const canvas = createRef<HTMLCanvasElement>();
    const inst = canvas.current as HTMLCanvasElement;
    const stat: Statistic[] = [];
    const ctx = new CanvasRenderingContext2D();
    const myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: stat.map(x => x.date.format('DD.MM')),
            datasets: stat.map(x => ({ label: x.subject.title, backgroundColor: x.subject.color, data: [x.value] })),
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
}