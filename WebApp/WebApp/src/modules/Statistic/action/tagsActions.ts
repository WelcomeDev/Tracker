import { TokenClient } from '../../Auth/actions/TokenClient';
import { Tag } from '../model/tag';
import { globalConfig } from '../../../config/globalConfig';

const URL = `${globalConfig.baseURL}/statistic`;

export function getTags() {
    return TokenClient.getInstance()
        .get<Tag[]>(`${URL}/tags/list`)
        .then(resp => resp.data);
}