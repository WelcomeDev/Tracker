import './filters.scss';
import { Select } from '../../../components/input/select/select';
import { tagsMockData } from '../MOCK/statisticTagsMock';
import { BaseSelectItem } from '../../../components/input/select/selectItem/baseSelectItem';
import { EditableSelectItem } from '../../../components/input/select/selectItem/editable/editableSelectItem';
import { MultipleSelectItem } from '../../../components/input/select/selectItem/multy/multipleSelectItem';
import { statisticSubjectsMock } from '../MOCK/statisticSubjectsMock';

export function Filters() {
    return (
        <div className={'filters-outer-wrapper'}>
            <div className={'filters-inner-wrapper'}>
                <Select>
                    {
                        tagsMockData.map(tag => (
                            <BaseSelectItem
                                SelectItem={EditableSelectItem}
                                props={{ ...tag }}/>
                        ))
                    }
                </Select>
                <Select>
                    {
                        statisticSubjectsMock.map(subject => (
                            <BaseSelectItem
                                SelectItem={MultipleSelectItem}
                                props={{ ...subject, id: subject.title }}/>
                        ))
                    }
                </Select>
            </div>
            <div className={'filters-inner-wrapper'}>

            </div>
        </div>
    );
}