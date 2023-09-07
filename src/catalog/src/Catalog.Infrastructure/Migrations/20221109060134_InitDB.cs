using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cat");

            migrationBuilder.CreateTable(
                name: "exams",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    default_question_number = table.Column<int>(type: "integer", nullable: false),
                    plus_score_per_question = table.Column<int>(type: "integer", nullable: false),
                    minus_score_per_question = table.Column<int>(type: "integer", nullable: false),
                    view_pass_question = table.Column<bool>(type: "boolean", nullable: false),
                    view_next_question = table.Column<bool>(type: "boolean", nullable: false),
                    show_all_question = table.Column<bool>(type: "boolean", nullable: false),
                    time_per_question = table.Column<int>(type: "integer", nullable: false),
                    shuffling_exams = table.Column<int>(type: "integer", nullable: false),
                    hide_result = table.Column<bool>(type: "boolean", nullable: false),
                    percentage_to_pass = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "levels",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "questionTypes",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "examResults",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    exam_id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    result_status = table.Column<string>(type: "text", nullable: false),
                    number_of_correct_answer = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exam_results", x => x.id);
                    table.ForeignKey(
                        name: "fk_exam_results_exams_exam_id",
                        column: x => x.exam_id,
                        principalSchema: "cat",
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    time = table.Column<int>(type: "integer", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    exam_id = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schedules", x => x.id);
                    table.ForeignKey(
                        name: "fk_schedules_exams_exam_id",
                        column: x => x.exam_id,
                        principalSchema: "cat",
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    question_content = table.Column<string>(type: "text", nullable: false),
                    question_type_id = table.Column<string>(type: "text", nullable: false),
                    level_id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    shuffle_answers = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questions", x => x.id);
                    table.ForeignKey(
                        name: "fk_questions_levels_level_id",
                        column: x => x.level_id,
                        principalSchema: "cat",
                        principalTable: "levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_questions_question_types_question_type_id",
                        column: x => x.question_type_id,
                        principalSchema: "cat",
                        principalTable: "questionTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionAnswers",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    exam_result_id = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<string>(type: "text", nullable: false),
                    answer_id = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_answers_exam_results_exam_result_id",
                        column: x => x.exam_result_id,
                        principalSchema: "cat",
                        principalTable: "examResults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    answer_content = table.Column<string>(type: "text", nullable: false),
                    answer_value = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<string>(type: "text", nullable: false),
                    allow_shuffle = table.Column<bool>(type: "boolean", nullable: false),
                    matching_position = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_answers", x => x.id);
                    table.ForeignKey(
                        name: "fk_answers_questions_question_id",
                        column: x => x.question_id,
                        principalSchema: "cat",
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_exam",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    exam_id = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_exam", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_exam_exams_exam_id",
                        column: x => x.exam_id,
                        principalSchema: "cat",
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_exam_questions_question_id",
                        column: x => x.question_id,
                        principalSchema: "cat",
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tag_questions",
                schema: "cat",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    tag_id = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_questions", x => x.id);
                    table.ForeignKey(
                        name: "fk_tag_questions_questions_question_id",
                        column: x => x.question_id,
                        principalSchema: "cat",
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tag_questions_tags_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "cat",
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cat",
                table: "levels",
                columns: new[] { "id", "created_by", "created_date", "deleted", "deleted_date", "description", "last_modified_by", "last_modified_date", "name" },
                values: new object[,]
                {
                    { "0293d928-8ec7-4bf7-82cf-894235220294", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(343), null, null, "Analysis", null, null, "Analysis" },
                    { "7b70ddba-b8b0-42f8-961e-20785f0f564b", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(332), null, null, "Knowledge", null, null, "Knowledge" },
                    { "999abd49-0b6d-4fd0-81f4-0a419b71bac8", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(349), null, null, "Evaluation", null, null, "Evaluation" },
                    { "abdbeff3-9840-4200-a8c6-e1f1e3d0c428", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(336), null, null, "Comprehension", null, null, "Comprehension" },
                    { "c363cdf9-cadb-4090-a03d-43c4f5303e9b", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(339), null, null, "Application", null, null, "Application" },
                    { "d3dd9e4d-0170-45ce-9ee2-78b9f8770e38", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(346), null, null, "Synthesis", null, null, "Synthesis" }
                });

            migrationBuilder.InsertData(
                schema: "cat",
                table: "questionTypes",
                columns: new[] { "id", "created_by", "created_date", "deleted", "deleted_date", "description", "last_modified_by", "last_modified_date", "name" },
                values: new object[,]
                {
                    { "01fd1f9c-78c4-41b1-a379-1229eba16808", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1052), null, null, "Ordering Sequence", null, null, "ORD" },
                    { "33ae4edc-9bc7-4201-afda-28d5cfa4e84e", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1050), null, null, "Match The Following", null, null, "MTF" },
                    { "42fe49d6-44f9-4006-af32-88f20c315023", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1046), null, null, "Fill In Blanks", null, null, "FIB" },
                    { "6f01c413-497a-4745-93d4-4e41d254fdad", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(1043), null, null, "Multiple Choice Question", null, null, "MCQ" }
                });

            migrationBuilder.InsertData(
                schema: "cat",
                table: "tags",
                columns: new[] { "id", "created_by", "created_date", "deleted", "deleted_date", "description", "last_modified_by", "last_modified_date", "name" },
                values: new object[,]
                {
                    { "056d3522-078a-4d46-9262-d56ea7e557ea", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5186), null, null, "Kỹ thuật lái xe", null, null, "4" },
                    { "244b45f1-fca2-4c6b-9a1f-71d7e44919c5", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5206), null, null, "Quy định tốc độ, khoảng cách", null, null, "10" },
                    { "64f5b16d-5656-4418-8b40-7cb4c972bdd4", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5203), null, null, "Quy tắc giao thông", null, null, "9" },
                    { "77f517bd-1855-4e0a-ac49-6893a707520c", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5180), null, null, "Nghiệp vụ vận tải", null, null, "2" },
                    { "7c99c1ee-a1c8-4e1b-a9a4-a174760e6dc2", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5183), null, null, "Văn hóa giao thông và đạo đức người lái xe", null, null, "3" },
                    { "80f521b3-c1d8-42ad-8c04-8e3d93e56fbe", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5200), null, null, "Các khái niệm", null, null, "8" },
                    { "b523c423-79c9-4d29-82ee-aec0ee4db213", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5194), null, null, "Các thế sa hình và kỹ năng xử lý tình huống giao thông", null, null, "7" },
                    { "b97ae130-8c1c-42b6-a47c-4e5e1fc056b6", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5192), null, null, "Hệ thống biển báo hiệu đường bộ", null, null, "6" },
                    { "bedbcaa0-fa15-4ee2-89a2-cbab79dd66ca", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5209), null, null, "Câu hỏi về tình huống mất an toàn giao thông nghiêm trọng (điểm liệt)", null, null, "11" },
                    { "d1879bda-01dd-43dd-afdd-3e01578e7864", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5176), null, null, "Khái niệm và quy tắc giao thông đường bộ", null, null, "1" },
                    { "f2919aa8-c48b-4311-870f-2ae3c80ac7fe", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(5189), null, null, "Cấu tạo và sửa chữa", null, null, "5" }
                });

            migrationBuilder.InsertData(
                schema: "cat",
                table: "questions",
                columns: new[] { "id", "created_by", "created_date", "deleted", "deleted_date", "last_modified_by", "last_modified_date", "level_id", "question_content", "question_type_id", "shuffle_answers", "user_id" },
                values: new object[] { "0b8d4bf8-635d-402f-a28a-41b8c344c33d", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(3260), null, null, null, null, "7b70ddba-b8b0-42f8-961e-20785f0f564b", "Just think,____2 years' time, we'll be 20 both.", "6f01c413-497a-4745-93d4-4e41d254fdad", true, "c4c93c76-e6bf-4608-8e84-dce4a1625fad" });

            migrationBuilder.InsertData(
                schema: "cat",
                table: "answers",
                columns: new[] { "id", "allow_shuffle", "answer_content", "answer_value", "created_by", "created_date", "deleted", "deleted_date", "last_modified_by", "last_modified_date", "matching_position", "question_id" },
                values: new object[,]
                {
                    { "35531282-6772-413c-99a0-57c8a7059c49", true, "over", "true", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4751), null, null, null, null, 0, "0b8d4bf8-635d-402f-a28a-41b8c344c33d" },
                    { "687e87df-d57a-4578-86df-3dc1938bfabb", true, "after", "true", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4742), null, null, null, null, 0, "0b8d4bf8-635d-402f-a28a-41b8c344c33d" },
                    { "c765cb93-f518-45ca-8372-0aa288f9d5b3", true, "under", "false", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4680), null, null, null, null, 0, "0b8d4bf8-635d-402f-a28a-41b8c344c33d" },
                    { "d079864f-2995-4357-8d3f-2784a1bffd23", true, "in", "false", null, new DateTime(2022, 11, 9, 6, 1, 34, 179, DateTimeKind.Utc).AddTicks(4737), null, null, null, null, 0, "0b8d4bf8-635d-402f-a28a-41b8c344c33d" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_answers_question_id",
                schema: "cat",
                table: "answers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_exam_results_exam_id",
                schema: "cat",
                table: "examResults",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_exam_exam_id",
                table: "question_exam",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_exam_question_id",
                table: "question_exam",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_answers_exam_result_id",
                schema: "cat",
                table: "questionAnswers",
                column: "exam_result_id");

            migrationBuilder.CreateIndex(
                name: "ix_questions_level_id",
                schema: "cat",
                table: "questions",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "ix_questions_question_type_id",
                schema: "cat",
                table: "questions",
                column: "question_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_schedules_exam_id",
                schema: "cat",
                table: "schedules",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_questions_question_id",
                schema: "cat",
                table: "tag_questions",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_tag_questions_tag_id",
                schema: "cat",
                table: "tag_questions",
                column: "tag_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "question_exam");

            migrationBuilder.DropTable(
                name: "questionAnswers",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "schedules",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "tag_questions",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "examResults",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "questions",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "tags",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "exams",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "levels",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "questionTypes",
                schema: "cat");
        }
    }
}
