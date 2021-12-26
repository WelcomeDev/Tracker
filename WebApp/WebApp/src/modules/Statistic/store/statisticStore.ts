import { action, makeAutoObservable } from 'mobx';
import { StatisticCollectionDto } from '../interfaces/statisticCollectionDto';
import { getStatistic } from '../action/statisticsActions';
import { StatisticParams } from '../interfaces/statisticParams';

export class StatisticStore {

    items: StatisticCollectionDto | null;

    constructor() {
        this.items = null;
        makeAutoObservable(this);
    }

    @action
    get = async (params: StatisticParams) => {
        this.items = await getStatistic(params);
    };
}