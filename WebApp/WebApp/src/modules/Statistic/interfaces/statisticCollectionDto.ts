import { StatisticDto } from './statisticDto';

export interface StatisticCollectionDto {
    dates: Date[],
    values: StatisticDto[]
}
