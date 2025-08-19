// @ts-check
const eslint = require('@eslint/js');
const tseslint = require('typescript-eslint');
const angular = require('angular-eslint');
const eslintPluginPrettierRecommended = require('eslint-plugin-prettier/recommended');
const eslintPluginBoundaries = require('eslint-plugin-boundaries');
const eslintImportPlugin = require('eslint-plugin-import');

module.exports = tseslint.config(
  {
    files: ['**/*.ts'],
    plugins: {
      'boundaries': eslintPluginBoundaries,
    },
    extends: [
      eslint.configs.recommended,
      ...tseslint.configs.recommended,
      ...tseslint.configs.stylistic,
      ...angular.configs.tsRecommended,
      eslintPluginPrettierRecommended,
      eslintImportPlugin.flatConfigs.recommended,
    ],
    processor: angular.processInlineTemplates,
    settings: {
      'import/resolver': {
        alias: {
          map: [
            ['@core', './src/app/core'],
            ['@shared', './src/app/shared'],
            ['@features', './src/app/features'],
          ],
          extensions: ['.ts', '.js', '.jsx', '.json', '.tsx'],
        },
      },
      'boundaries/elements': [
        { type: 'core', pattern: 'src/app/core/**' },
        { type: 'shared', pattern: 'src/app/shared/**' },
        { type: 'features', pattern: 'src/app/features/**' },
      ],
    },
    rules: {
      '@angular-eslint/directive-selector': [
        'error',
        {
          type: 'attribute',
          prefix: 'app',
          style: 'camelCase',
        },
      ],
      '@angular-eslint/component-selector': [
        'error',
        {
          type: 'element',
          prefix: 'app',
          style: 'kebab-case',
        },
      ],
      'boundaries/element-types': [
        'error',
        {
          default: 'disallow',
          rules: [
            { from: 'core', allow: ['core', 'shared'] },
            { from: 'shared', allow: ['shared'] },
            { from: 'features', allow: ['core', 'shared', 'features'] },
          ],
        },
      ],
      'import/no-unresolved': 'off',
      'import/named': 'off',
    },
  },
  {
    files: ['**/*.html'],
    extends: [...angular.configs.templateRecommended, ...angular.configs.templateAccessibility],
    rules: {},
  },
);
