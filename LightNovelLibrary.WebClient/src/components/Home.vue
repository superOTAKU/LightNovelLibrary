<script setup lang="ts">
    import {getTags} from '@/apis/tag'
    import {reactive, onBeforeMount} from 'vue'
    import {Tag} from '@/types/index'

    const tags = reactive<Tag[]>([])

    onBeforeMount(async () => {
        (await getTags()).forEach(tag => tags.push(tag))
    })
</script>

<template>
    <van-nav-bar :title="$t('core.title')"/>
    <!--FIXME:选一个前端布局css类库 -->
    <div style="padding: 10px;">
        <!-- 展示所有分类 -->
        <van-space style="margin: 10px 0">
            <van-tag type="primary" size="large" v-for="tag in tags" :key="tag.id">{{ tag.name }}</van-tag>
        </van-space>
    </div>
</template>