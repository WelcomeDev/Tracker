import { globalConfig } from '../../../config/globalConfig';
import { TokenClient } from '../../Auth/actions/TokenClient';
import { Title } from '../model/title';

const URL = `${globalConfig.baseURL}/statistic`;

export function getTitles(tagName: string) {
    return TokenClient.getInstance()
        .get<Title[]>(`${URL}/titles/list`, {
            params: {
                tagName,
            },
        })
        .then(resp => resp.data);
}