import { createRef } from 'react';
import { Chart, ChartData } from 'chart.js';

// import Chart from 'chartjs';

const chartData: ChartData = {};

export function ChartLayout() {

    const canvas = createRef<HTMLCanvasElement>();
    const inst = canvas.current as HTMLCanvasElement;
    const ctx = new CanvasRenderingContext2D();
    const myChart = new Chart(ctx, {
        type: 'bar',
        data: chartData,
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