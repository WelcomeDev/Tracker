import { observable } from 'mobx';
import { Statistic } from '../modules/Statistic/model/statistic';

export class StatisticStore {
    @observable statisticItems: Statistic[];

//todo: complete implementation
    constructor() {
        this.statisticItems = [];
    }
}