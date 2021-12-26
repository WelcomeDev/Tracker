import { TokenClient } from '../../Auth/actions/TokenClient';
import { globalConfig } from '../../../config/globalConfig';
import { StatisticCollectionDto } from '../interfaces/statisticCollectionDto';
import { CreateStatisticsParams } from '../interfaces/createStatisticsParams';
import { StatisticParams } from '../interfaces/statisticParams';

const URL = `${globalConfig.baseURL}/statistic`;

export function getStatistic(params: StatisticParams): Promise<StatisticCollectionDto> {
    return TokenClient.getInstance()
        .get<StatisticCollectionDto>(`${URL}/list`, {
            params,
        })
        .then(resp => resp.data);
}

export function create(params: CreateStatisticsParams[]) {
    return TokenClient.getInstance()
        .post(`${URL}/create`, params);
}
