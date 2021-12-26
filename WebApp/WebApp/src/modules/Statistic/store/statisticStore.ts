import { action, makeAutoObservable } from 'mobx';
import { StatisticCollectionDto } from '../interfaces/statisticCollectionDto';
import { getStatistic } from '../action/statisticsActions';
import { StatisticParams } from '../interfaces/statisticParams';
import { Tag } from '../model/tag';
import { Title } from '../model/title';

export class StatisticStore {

    items: StatisticCollectionDto | null;
    tags: Tag[];
    tagTitles: Title[] | null;

    constructor() {
        this.items = null;
        this.tags = [];
        this.tagTitles = [];
        makeAutoObservable(this);
    }

    @action
    getStatistic = async (params: StatisticParams) => {
        this.items = await getStatistic(params);
    };

    @action
    getTitles = async (tagName: string) => {

    };

    @action
    getTags = async () => {

    };
}