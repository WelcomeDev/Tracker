import './filters.scss';
import { Select } from '../../../components/input/select/select';
import { BaseSelectItem } from '../../../components/input/select/selectItem/baseSelectItem';
import { EditableSelectItem } from '../../../components/input/select/selectItem/editable/editableSelectItem';
import { MultipleSelectItem } from '../../../components/input/select/selectItem/multy/multipleSelectItem';
import { observer } from 'mobx-react';
import { useStatisticStore } from '../../../modules/Statistic/hooks/context/statisticProvider';
import { Loader } from '../../components/loader/loader';
import { useEffect, useState } from 'react';
import moment from 'moment';

export const Filters = observer(() => {

    const { tags, tagTitles, getStatistic } = useStatisticStore();
    const [selectedTag, setSelectedTag] = useState<string>(tags[0]?.name);

    useEffect(
        () => {
            setSelectedTag(tags[0]?.name);
        }, [tags]);

    function onSetSelectedTag({ name, id }: { name: string, id: string }) {
        setSelectedTag(name);
        getStatistic(
            {
                tagName: name,
                from: moment()
                    .subtract(7, 'd')
                    .format('yyyy-MM-DD'),
                to: moment()
                    .format('yyyy-MM-DD'),
            });
    }

    return (
        <div
            className={'content-container'}
        >
            <div className={'filters-outer-wrapper'}>
                <div className={'filters-inner-wrapper'}>
                    <Select
                        selection={selectedTag}
                    >
                        {
                            tags.map(tag => (
                                <BaseSelectItem
                                    SelectItem={EditableSelectItem}
                                    props={{ ...tag, onSelectCallback: onSetSelectedTag }}/>
                            ))
                        }
                    </Select>
                    {/*<Select>*/}
                    {/*    {*/}
                    {/*        tagTitles*/}
                    {/*            ? tagTitles.map(subject => (*/}
                    {/*                <BaseSelectItem*/}
                    {/*                    SelectItem={MultipleSelectItem}*/}
                    {/*                    props={{ ...subject }}/>*/}
                    {/*            ))*/}
                    {/*            : <Loader/>*/}
                    {/*    }*/}
                    {/*</Select>*/}
                </div>
                <div className={'filters-inner-wrapper'}>

                </div>
            </div>
        </div>
    );
});