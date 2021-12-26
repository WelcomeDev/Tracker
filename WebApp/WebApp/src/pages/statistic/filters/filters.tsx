import './filters.scss';
import { Select } from '../../../components/input/select/select';
import { BaseSelectItem } from '../../../components/input/select/selectItem/baseSelectItem';
import { EditableSelectItem } from '../../../components/input/select/selectItem/editable/editableSelectItem';
import { MultipleSelectItem } from '../../../components/input/select/selectItem/multy/multipleSelectItem';
import { observer } from 'mobx-react';
import { useStatisticStore } from '../../../modules/Statistic/hooks/context/statisticProvider';
import { Loader } from '../../components/loader/loader';

export const Filters = observer(() => {

    const { tags, tagTitles } = useStatisticStore();

    return (
        <div className={'filters-outer-wrapper'}>
            <div className={'filters-inner-wrapper'}>
                <Select>
                    {
                        tags.map(tag => (
                            <BaseSelectItem
                                SelectItem={EditableSelectItem}
                                props={{ ...tag }}/>
                        ))
                    }
                </Select>
                <Select>
                    {
                        tagTitles
                            ? tagTitles.map(subject => (
                                <BaseSelectItem
                                    SelectItem={MultipleSelectItem}
                                    props={{ ...subject }}/>
                            ))
                            : <Loader/>
                    }
                </Select>
            </div>
            <div className={'filters-inner-wrapper'}>

            </div>
        </div>
    );
});